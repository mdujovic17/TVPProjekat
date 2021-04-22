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
using TVPProjekat.forms.pomocne;
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    public partial class FormKupac : Form
    {
        public delegate void Osvezi(bool osvezi);

        private static Kupac prijavljenKupac;
        public Form frmLogin;
        private Form frmRezervacija;
        private List<object> listaRezervacija;

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
        }

        private void izlaz(object sender, FormClosedEventArgs e)
        {
            frmLogin.Close();
        }

        private void nalogInfo(object sender, EventArgs e)
        {
            MessageBox.Show($"Korisnicko ime: {prijavljenKupac.KorisnickoIme}\nE-Mail: {prijavljenKupac.Email}\nIme i prezime: {prijavljenKupac.Ime} {prijavljenKupac.Prezime}\nBroj telefona: {prijavljenKupac.Telefon}\nPol: {prijavljenKupac.StrPol()}\nDatum rođenja: {prijavljenKupac.DatumRodjenja.ToString("dd/MM/yyyy")}\nUUID: {prijavljenKupac.KupacUUID}");
        }

        private void btnRezervacija_Click(object sender, EventArgs e)
        {
            frmRezervacija = new FormRezervacija();
            frmRezervacija.Show();
        }
    }
}
