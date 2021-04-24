using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.korisnik;
using TVPProjekat.util;

namespace TVPProjekat.forms.pomocne
{
    public partial class FormIzmenaKorisnik : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        private static Korisnik korisnikZaIzmenu;
        private static string prikrivenaLozinka;

        private FormAdmin frmAdmin;
        
        public FormIzmenaKorisnik()
        {
            InitializeComponent();
            dateDatum.MaxDate = DateTime.Now;
        }

        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }

        public Korisnik prihvatiKorisnika(Korisnik korisnik, string shadowPass)
        {
            prikrivenaLozinka = shadowPass;
            return korisnikZaIzmenu = korisnik; 
        }

        private void potvrdiIzmene(object sender, EventArgs e)
        {
            if (ProveraForme.proveraImena(txtIme.Text) && ProveraForme.proveraImena(txtPrezime.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value) &&
                ProveraForme.proveraPola(comboPol.SelectedIndex) && ProveraForme.proveraKorImena(txtKorisnickoIme.Text) && ProveraForme.proveraBrojaTelefona(txtTelefon.Text)) 
            {
                korisnikZaIzmenu.Ime = this.txtIme.Text;
                korisnikZaIzmenu.Prezime = this.txtPrezime.Text;
                korisnikZaIzmenu.KorisnickoIme = this.txtKorisnickoIme.Text;
                korisnikZaIzmenu.Pol = this.comboPol.SelectedIndex;
                korisnikZaIzmenu.Telefon = this.txtTelefon.Text;
                korisnikZaIzmenu.DatumRodjenja = this.dateDatum.Value;
                if (this.txtUUID.Enabled)
                {
                    if (korisnikZaIzmenu is Administrator) (korisnikZaIzmenu as Administrator).AdminUUID = this.txtUUID.Text;
                    if (korisnikZaIzmenu is Kupac) (korisnikZaIzmenu as Kupac).KupacUUID = this.txtUUID.Text;
                }

                if (korisnikZaIzmenu is Administrator)
                {
                    LocalFileManager.JSONSerialize(korisnikZaIzmenu, "administratori");
                    prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                    azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                    prikaz();
                    azuriraj(sender, e);

                }
                else if (korisnikZaIzmenu is Kupac)
                {
                    LocalFileManager.JSONSerialize(korisnikZaIzmenu, "kupci");
                    prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                    azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                    prikaz();
                    azuriraj(sender, e);
                }

                this.Dispose();
                this.Close();

                //MessageBox.Show("Potrebno je osveziti listu da bi ste videli izmene.", "Izmena podataka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void popuniFormu(object sender, EventArgs e)
        {
            this.txtIme.Text = korisnikZaIzmenu.Ime;
            this.txtPrezime.Text = korisnikZaIzmenu.Prezime;
            this.txtEmail.Text = korisnikZaIzmenu.Email;
            this.txtLozinka.Text = prikrivenaLozinka;
            this.txtKorisnickoIme.Text = korisnikZaIzmenu.KorisnickoIme;
            this.txtTelefon.Text = korisnikZaIzmenu.Telefon;
            this.dateDatum.Value = korisnikZaIzmenu.DatumRodjenja;
            this.comboPol.SelectedIndex = korisnikZaIzmenu.Pol;

            if (korisnikZaIzmenu is Administrator)
            {
                this.txtUUID.Text = (korisnikZaIzmenu as Administrator).AdminUUID;
                lblAdmin.Text = (korisnikZaIzmenu as Administrator).IsAdmin.ToString();
            }
            if (korisnikZaIzmenu is Kupac)
            {
                if ((korisnikZaIzmenu as Kupac).KupacUUID.Length == 2)
                {
                    this.txtUUID.Enabled = true;
                }
                else
                {
                    this.txtUUID.Enabled = false;
                }
                this.txtUUID.Text = (korisnikZaIzmenu as Kupac).KupacUUID;
                lblAdmin.Text = (korisnikZaIzmenu as Kupac).IsAdmin.ToString();
            }
        }

        private void otkaziIzmene(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
