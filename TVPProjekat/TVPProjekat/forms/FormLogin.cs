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
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    public partial class FormLogin : Form
    {
        public delegate Korisnik posaljiKorisnika(Korisnik korisnik);

        private bool provera = false;

        private static bool prikaz = true;

        FormRegistracija formaZaRegistraciju;
        FormKupac frmKupac;
        FormAdmin frmAdmin;

        List<Korisnik> listaKorisnika;
        //List<Korisnik> listaLozinki;
        public FormLogin()
        {
            InitializeComponent();
            listaKorisnika = new List<Korisnik>();
        }

        private void otvoriRegistracionuFormu(object sender, EventArgs e)
        {
            formaZaRegistraciju = new FormRegistracija();
            formaZaRegistraciju.Show();
        }

        //Proverava unete podatke sa listom korisnika. Ako su podaci tacni, taj korisnik se salje u predvidjenu formu putem delegata.
        private void prijaviKorisnika(string username, string password)
        {
            string tempUsername, tempPassword;
            //string uuid;
            foreach (Korisnik k in listaKorisnika)
            {
                Kupac k1 = k as Kupac;
                Administrator a1 = k as Administrator;

                if (username.Equals(k.KorisnickoIme) || username.Equals(k.Email))
                {
                    tempUsername = username;

                    if (password != Korisnik.desifrujLozinku(k.Sifra))
                    {
                        MessageBox.Show("Uneli ste pogresno korisnicko ime ili lozinku!", "Pogresno uneti podaci", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        provera = false;
                        break;
                    }
                    else
                    {
                        tempPassword = password;
                        if (k1 != null)
                        {
                            frmKupac = new FormKupac();
                            posaljiKorisnika prijava = FormKupac.PrihvatiKorisnika;
                            provera = true;
                            prijava(k1);
                        }
                        else if (a1 != null)
                        {
                            frmAdmin = new FormAdmin();
                            posaljiKorisnika prijava = FormAdmin.PrihvatiKorisnika;
                            provera = true;
                            prijava(a1);
                        }
                    }

                    break;
                }
            }
        }

        private void UcitajBazu(object sender, EventArgs e)
        {
            //Ucitaj listu korisnika iz fajlova.
            LocalFileManager lfm = new LocalFileManager(); //Ucitava osnovnu listu korisnika (..\data\default.csv)
            listaKorisnika = lfm.UserCSVRead();
            Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") +" "+ "[UPOZORENJE]: Ucitana je baza osnovnih naloga!");
            //LocalFileManager.CitajXMLAdmina(listaKorisnika);
            LocalFileManager.JSONDeserialize(listaKorisnika, "administratori");
            LocalFileManager.JSONDeserialize(listaKorisnika, "kupci");

        }

        //Poziva prijavu korisnika, ako je uspesno prijavljivanje, ova forma se sakriva.
        private void prijava(object sender, EventArgs e)
        {
            prijaviKorisnika(txtUsername.Text, txtPassword.Text);

            if (provera)
            {
                frmAdmin.frmLogin = this;

                frmAdmin.Show();
                this.Hide();
            }
        }

        //Ako se neki od korisnika odjavi, ucitavaju se baze administratora i korisnika
        //U slucaju da je doslo do izmene
        private void OsveziBazu(object sender, EventArgs e)
        {
            if (!prikaz)
            {
                Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "[INFO]: Osvezavanje baze...");
                listaKorisnika.Clear();
                UcitajBazu(sender, e);
            }
        }

        //Kontrolise osvezavanje baze, poziva se preko delegata iz drugih formi.
        //True vrednost blokira osvezavanje, False dozvoljava.
        public static void osvezi(bool test)
        {
            prikaz = test;
        }
    }
}
