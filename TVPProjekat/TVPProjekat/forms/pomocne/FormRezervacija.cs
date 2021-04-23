using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.bioskop;
using TVPProjekat.korisnik;

namespace TVPProjekat.forms.pomocne
{
    public partial class FormRezervacija : Form
    {
        private Form frmKupac;
        private Korisnik kupac;

        double cena = 0.00;

        List<Sala> sale;
        List<Film> filmovi;
        List<Projekcija> projekcije;

        private Projekcija selectedItem;

        private Rezervacija novaRezervacija;
        public FormRezervacija()
        {
            InitializeComponent();
            datePocetniDatum.MinDate = DateTime.Now;
            sale = new List<Sala>();
            filmovi = new List<Film>();
            projekcije = new List<Projekcija>();
            btnRezervisi.Enabled = false;
        }

        public void primiKupca(Korisnik korisnik)
        {
            kupac = korisnik;
        }

        public void listUpdate()
        {
            sale = new List<Sala>();
            filmovi = new List<Film>();
            projekcije = new List<Projekcija>();

            LocalFileManager.JSONDeserialize(sale, "sale");
            LocalFileManager.JSONDeserialize(filmovi, "filmovi");
            LocalFileManager.JSONDeserialize(projekcije, "projekcije");
        }

        private void ucitajPodatke(object sender, EventArgs e)
        {
            listUpdate();

            foreach (Sala sala in sale)
            {
                comboSale.Items.Add("Sala " + sala.BrojSale);
            }
            foreach (Film film in filmovi)
            {
                comboNazivFilma.Items.Add(film.ImeFilma);
            }
            foreach (Projekcija projekcija in projekcije)
            {
                if (projekcija.DostupnaMesta != 0)
                {
                    ListViewItem item = new ListViewItem(new[] { projekcija.Film.ImeFilma, projekcija.Film.Trajanje.ToString() + " min", projekcija.CenaKarte.ToString("0.00") + " RSD", projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm"), "Sala " + projekcija.Sala.ToString(), projekcija.DostupnaMesta.ToString() });
                    lvProjekcije.Items.Add(item);
                }
            }
            txtCena.Text = cena.ToString("0.00");
        }

        private void selektujObjekat(object sender, EventArgs e)
        {
            string selektovanFilm = "";
            foreach (ListViewItem item in lvProjekcije.SelectedItems)
            {
                selektovanFilm = item.SubItems[0].Text; //Uzima ime filma
            }

            foreach (Projekcija projekcija in projekcije)
            {
                if (projekcija.Film.ImeFilma.Equals(selektovanFilm))
                {
                    selectedItem = projekcija;
                    Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "Selektovan film: " + projekcija.Film.ImeFilma);
                    break;
                }
            }

            racunajCenu(sender, e);
        }

        public void primiFormu(FormKupac forma)
        {
            frmKupac = forma;
        }

        private void zatvori(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            this.Close();
            frmKupac.Show();
        }

        private void filtriraj(object sender, EventArgs e)
        {
            listViewClear();
            bool salaNotSelected = comboSale.SelectedIndex == -1;
            bool imeFilmaNotSelected = comboNazivFilma.SelectedIndex == -1;
            foreach (Projekcija projekcija in projekcije)
            {
                ListViewItem item = new ListViewItem(new[] { projekcija.Film.ImeFilma, projekcija.Film.Trajanje.ToString() + " min", projekcija.CenaKarte.ToString("0.00") + " RSD", projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm"), "Sala " + projekcija.Sala.ToString(), projekcija.DostupnaMesta.ToString() });
                
                bool datum = datePocetniDatum.Value < projekcija.DatumProjekcije && dateKrajniDatum.Value > projekcija.DatumProjekcije;
                bool sala = !salaNotSelected && projekcija.Sala == int.Parse(comboSale.SelectedItem.ToString().Replace("Sala ", ""));
                bool imeFilma = !imeFilmaNotSelected && projekcija.Film.ImeFilma.Equals(comboNazivFilma.SelectedItem.ToString());

                if (datum)
                {
                    if (salaNotSelected)
                    {
                        if (imeFilmaNotSelected)
                        {
                            lvProjekcije.Items.Add(item);
                        }
                        else
                        {
                            lvProjekcije.Items.Add(item);
                        }
                    }
                    else if (sala)
                    {
                        if (imeFilmaNotSelected)
                        {
                            lvProjekcije.Items.Add(item);
                        }
                        else if (imeFilma)
                        {
                            lvProjekcije.Items.Add(item);
                        }
                    }
                    
                }
            }
        }

        private void rezervisi(object sender, EventArgs e)
        {
            if (selectedItem.DostupnaMesta >= (int)numBrojMesta.Value)
            {
                novaRezervacija = new Rezervacija((kupac as Kupac).KupacUUID, selectedItem.Uid, (int)numBrojMesta.Value, double.Parse(txtCena.Text));
                LocalFileManager.JSONSerialize(novaRezervacija, "rezervacije");
                selectedItem.DostupnaMesta -= (int)numBrojMesta.Value;
                LocalFileManager.JSONSerialize(selectedItem, "projekcije");
                MessageBox.Show("Uspesno ste rezervisali projekciju", "Rezervacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Projekcija nema dovoljno slobodnih mesta!", "Rezervacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewClear()
        {
            lvProjekcije.Items.Clear();
        }

        private void racunajCenu(object sender, EventArgs e)
        {
            if (selectedItem != null)
            {
                cena = selectedItem.CenaKarte * (double)numBrojMesta.Value;
                txtCena.Text = cena.ToString("0.00");
                if (numBrojMesta.Value == 0)
                {
                    btnRezervisi.Enabled = false;
                }
                else
                {
                    btnRezervisi.Enabled = true;
                }
            }
        }

        private void resetFilter(object sender, EventArgs e)
        {
            listViewClear();
            ucitajPodatke(sender, e);
        }

        private void izadji(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            frmKupac.Show();
        }
    }
}
