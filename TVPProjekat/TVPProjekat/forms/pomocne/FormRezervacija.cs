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

namespace TVPProjekat.forms.pomocne
{
    public partial class FormRezervacija : Form
    {
        private static Form frmKupac;

        double cena = 0.00;

        List<Sala> sale;
        List<Film> filmovi;
        List<Projekcija> projekcije;

        private Projekcija selectedItem;
        public FormRezervacija()
        {
            InitializeComponent();
            datePocetniDatum.MinDate = DateTime.Now;
            sale = new List<Sala>();
            filmovi = new List<Film>();
            projekcije = new List<Projekcija>();
            btnRezervisi.Enabled = false;
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
                ListViewItem item = new ListViewItem(new[] { projekcija.Film.ImeFilma, projekcija.Film.Trajanje.ToString() + " min", projekcija.CenaKarte.ToString("0.00") + " RSD", projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm"), "Sala " + projekcija.Sala.ToString(), projekcija.DostupnaMesta.ToString() });
                lvProjekcije.Items.Add(item);
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

        public static void primiFormu(FormKupac forma)
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
            foreach (Projekcija projekcija in projekcije)
            {
                ListViewItem item = new ListViewItem(new[] { projekcija.Film.ImeFilma, projekcija.Film.Trajanje.ToString() + " min", projekcija.CenaKarte.ToString("0.00") + " RSD", projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm"), "Sala " + projekcija.Sala.ToString(), projekcija.DostupnaMesta.ToString() });
                
                bool datum = datePocetniDatum.Value < projekcija.DatumProjekcije && dateKrajniDatum.Value > projekcija.DatumProjekcije;
                bool sala = comboSale.SelectedIndex != -1 && projekcija.Sala == int.Parse(comboSale.SelectedItem.ToString().Replace("Sala ", ""));
                bool imeFilma = comboNazivFilma.SelectedIndex != -1 && projekcija.Film.ImeFilma.Equals(comboNazivFilma.SelectedItem.ToString());

                if (datum)
                {
                    if (sala && !imeFilma)
                    {
                        lvProjekcije.Items.Add(item);
                    }
                    else if (imeFilma && sala)
                    {
                        lvProjekcije.Items.Add(item);
                    }
                    //else if (sala && imeFilma)
                    //{
                    //    lvProjekcije.Items.Add(item);
                    //}
                }
            }
        }

        private void rezervisi(object sender, EventArgs e)
        {

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
    }
}
