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
        private delegate void Osvezi(bool osvezi);
        private delegate void posaljiKorisnika(Korisnik korisnik);
        private delegate void posaljiFormu(FormKupac formKupac);

        private Kupac prijavljenKupac;
        private FormLogin frmLogin;
        private FormRezervacija frmRezervacija;
        private FormDetaljiNaloga frmDetalji;

        private List<Rezervacija> listaRezervacija;
        private List<Film> listaFilmova;
        private List<Projekcija> listaProjekcija;

        private Rezervacija selectedItem;
        public FormKupac()
        {
            InitializeComponent();
            listUpdate();
        }
        public void listUpdate()
        {
            listaRezervacija = new List<Rezervacija>();
            listaFilmova = new List<Film>();
            listaProjekcija = new List<Projekcija>();

            LocalFileManager.JSONDeserialize(listaRezervacija, "rezervacije");
            LocalFileManager.JSONDeserialize(listaFilmova, "filmovi");
            LocalFileManager.JSONDeserialize(listaProjekcija, "projekcije");
        }
        public Korisnik PrihvatiKorisnika(Korisnik kupac)
        {
            prijavljenKupac = kupac as Kupac;
            Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "[INFO]: Prijavljivanje kupca sa UUID: " + prijavljenKupac.KupacUUID);
            return kupac;
        }
        public void prihvatiFormu(Form formLogin)
        {
            frmLogin = formLogin as FormLogin;
        }
        private void btnOdjava_Click(object sender, EventArgs e)
        {
            prijavljenKupac = null;
            if (listaRezervacija != null)
            {
                listaRezervacija = null;
            }

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
            frmRezervacija = new FormRezervacija();
            posaljiFormu posalji = new posaljiFormu(frmRezervacija.primiFormu);
            posaljiKorisnika posaljiKorisnika = new posaljiKorisnika(frmRezervacija.primiKupca);
            posalji(this);
            posaljiKorisnika(prijavljenKupac);
            frmRezervacija.Show();
            this.Hide();
        }
        private void listViewClear()
        {
            lvRezervacije.Items.Clear();
        }
        private void prikaziListu(object sender, EventArgs e)
        {
            listViewClear();

            listUpdate();

            foreach (Rezervacija rezervacija in listaRezervacija)
            {
                if (rezervacija.KorisnickiID == prijavljenKupac.KupacUUID)
                {
                    foreach (Projekcija projekcija in listaProjekcija)
                    {
                        if (rezervacija.ProjekcijaID == projekcija.Uid)
                        {
                            ListViewItem item = new ListViewItem(new[] { rezervacija.KorisnickiID + "-" + rezervacija.ProjekcijaID, projekcija.Film.ImeFilma, "Sala " + projekcija.Sala, projekcija.DatumProjekcije.ToString("dd/MM/yyyy") + " " + projekcija.VremeProjekcije.ToString("HH:mm"), rezervacija.BrojMesta.ToString(), rezervacija.Cena.ToString("0.00") });
                            lvRezervacije.Items.Add(item);
                            break;
                        }
                    }
                    
                }
            }
        }
        private void otkaziRezervaciju(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Da li ste sigurni da zelite da otkazete rezervaciju?", "Otkazivanje rezervacije", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (msg == DialogResult.Yes)
            {
                LocalFileManager.JSONDelete(selectedItem);
                listUpdate();
            }
        }
        private void kontrola(string uuid)
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
