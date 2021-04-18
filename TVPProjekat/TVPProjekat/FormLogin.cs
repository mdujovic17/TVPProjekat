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

namespace TVPProjekat
{
    public partial class FormLogin : Form
    {
        public delegate Korisnik posaljiKorisnika(Korisnik korisnik);

        FormRegistracija formaZaRegistraciju;
        FormKupac frmKupac;
        FormAdmin frmAdmin;

        List<Korisnik> listaKorisnika;
        List<Korisnik> listaLozinki;
        Korisnik prijavljenKorisnik;
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

        private void prijaviKorisnika(string username, string password)
        {
            string tempUsername, tempPassword;
            string uuid;
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
                        break;
                    }
                    else
                    {
                        tempPassword = password;
                        if (k1 != null)
                        {
                            frmKupac = new FormKupac();
                            posaljiKorisnika prijava = FormKupac.PrihvatiKorisnika;
                            prijava(k1);
                            frmKupac.Show();
                        }
                        else if (a1 != null)
                        {
                            frmAdmin = new FormAdmin();
                            posaljiKorisnika prijava = FormAdmin.PrihvatiKorisnika;
                            prijava(a1);
                            frmAdmin.Show();
                        }
                    }

                    break;
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            //Ucitaj listu korisnika iz fajlova.
            LocalFileManager lfm = new LocalFileManager();
            listaKorisnika = lfm.UserCSVRead();
        }

        private void prijava(object sender, EventArgs e)
        {
            prijaviKorisnika(txtUsername.Text, txtPassword.Text);
        }
    }
}
