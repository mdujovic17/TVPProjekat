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
using TVPProjekat.forms.pomocne;
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    public partial class FormKupac : Form
    {
        public delegate void Osvezi(bool osvezi);
        public delegate void posaljiKorisnika(Korisnik korisnik);
        public delegate void posaljiFormu(FormKupac formKupac);

        private static Kupac prijavljenKupac;
        public Form frmLogin;
        private Form frmRezervacija;
        private Form frmDetalji;
        private List<Rezervacija> listaRezervacija;
        private List<Film> listaFilmova;
        private List<Projekcija> listaProjekcija;

        private Rezervacija selectedItem;

        Osvezi osvezavanje = FormLogin.osvezi;
        public FormKupac()
        {
            InitializeComponent();
            osvezavanje(true);
        }
        public static Korisnik PrihvatiKorisnika(Korisnik kupac)
        {
            prijavljenKupac = kupac as Kupac;
            Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "[INFO]: Prijavljivanje kupca sa UUID: " + prijavljenKupac.KupacUUID);
            return kupac;
        }
        private void btnOdjava_Click(object sender, EventArgs e)
        {
            prijavljenKupac = null;
            if (listaRezervacija != null)
            {
                listaRezervacija = null;
            }

            osvezavanje(false);

            frmLogin.Show();
            this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
            this.Close();
        }
        private void loadKupacPanel(object sender, EventArgs e)
        {
            this.stripUser.Text += prijavljenKupac.Ime;
            this.stripStatus.Text += "Kupac";
            prikaziListu(sender, e);
        }
        private void izlaz(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            frmLogin.Close();
        }
        private void nalogInfo(object sender, EventArgs e)
        {
            MessageBox.Show($"Korisnicko ime: {prijavljenKupac.KorisnickoIme}\nE-Mail: {prijavljenKupac.Email}\nIme i prezime: {prijavljenKupac.Ime} {prijavljenKupac.Prezime}\nBroj telefona: {prijavljenKupac.Telefon}\nPol: {prijavljenKupac.StrPol()}\nDatum rođenja: {prijavljenKupac.DatumRodjenja.ToString("dd/MM/yyyy")}\nUUID: {prijavljenKupac.KupacUUID}");
        }
        private void btnRezervacija_Click(object sender, EventArgs e)
        {
            posaljiFormu posalji = FormRezervacija.primiFormu;
            frmRezervacija = new FormRezervacija();
            posalji(this);
            frmRezervacija.Show();
            this.Hide();
        }
        private void prikaziListu(object sender, EventArgs e)
        {
            listaRezervacija = new List<Rezervacija>();
            listaFilmova = new List<Film>();
            listaProjekcija = new List<Projekcija>();

            LocalFileManager.JSONDeserialize(listaRezervacija, "rezervacije");
            LocalFileManager.JSONDeserialize(listaFilmova, "filmovi");
            LocalFileManager.JSONDeserialize(listaProjekcija, "projekcije");

            string imeFilma = "", sala = "", datumIVreme = "";

            for (int i = 0; i < listaRezervacija.Count; i++)
            {
                Rezervacija r = listaRezervacija[i];
                foreach (Projekcija projekcija in listaProjekcija)
                {
                    if (r.ProjekcijaID.Equals(projekcija.Uid))
                    {
                        imeFilma = projekcija.Film.ImeFilma;
                        sala = "Sala " + projekcija.Sala;
                        datumIVreme = projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm");
                        break;
                    }
                }
                ListViewItem item = new ListViewItem(new[] { r.KorisnickiID + "-" + r.ProjekcijaID, imeFilma, sala, datumIVreme, r.BrojMesta.ToString(), r.Cena.ToString("0.00") });
                lvRezervacije.Items.Add(item);
            }
        }
        private void otkaziRezervaciju(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Da li ste sigurni da zelite da otkazete rezervaciju?", "Otkazivanje rezervacije", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (msg == DialogResult.Yes)
            {
                LocalFileManager.JSONDelete(selectedItem);
            }
        }
        private void kontrola(string uuid)
        {
            if (uuid.Length == 20 || uuid.Length == 21 || uuid.Length == 22)
            {
                foreach (Rezervacija rezervacija in listaRezervacija)
                {
                    if ((rezervacija.KorisnickiID + "-" + rezervacija.ProjekcijaID).Equals(uuid))
                    {
                        selectedItem = rezervacija;
                        Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "Selektovana rezervacija sa UUID: " + (rezervacija.KorisnickiID + "-" + rezervacija.ProjekcijaID));
                        break;
                    }
                }
            }
        }
        private void detaljiNaloga(object sender, EventArgs e)
        {
            posaljiKorisnika posalji = FormDetaljiNaloga.prihvatiKorisnika;

            frmDetalji = new FormDetaljiNaloga();
            posalji(prijavljenKupac);
            frmDetalji.Show();
        }

        private void selektujObjekat(object sender, EventArgs e)
        {
            string selektovanUUID = "";
            foreach (ListViewItem item in lvRezervacije.SelectedItems)
            {
                selektovanUUID = item.SubItems[0].Text; //Uzima UUID
            }
            kontrola(selektovanUUID);

            if (selektovanUUID.Equals(""))
            {
                btnOtkazi.Enabled = false;
            }
            else
            {
                btnOtkazi.Enabled = true;
            }
        }
    }
}
