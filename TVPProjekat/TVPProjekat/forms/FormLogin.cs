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
    public partial class FormLogin : Form
    {
        private delegate Korisnik posaljiKorisnika(Korisnik korisnik);
        private delegate void posaljiFormu(Form form);

        posaljiFormu posaljiFrm;

        private bool prikaz = true;

        FormRegistracija formaZaRegistraciju;
        FormKupac frmKupac;
        FormAdmin frmAdmin;
        FormLozinkaReset frmReset;

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
            string uuid;
            bool postoji = false;
            foreach (Korisnik k in listaKorisnika)
            {
                Kupac k1 = k as Kupac;
                Administrator a1 = k as Administrator;

                if (username.Equals(k.KorisnickoIme) || username.Equals(k.Email))
                {
                    tempUsername = username;
                    postoji = true;
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
                            uuid = k1.KupacUUID;
                            if (uuid != "-1")
                            {
                                frmKupac = new FormKupac();
                                posaljiKorisnika prijava = new posaljiKorisnika(frmKupac.PrihvatiKorisnika);
                                posaljiFrm = new posaljiFormu(frmKupac.prihvatiFormu);
                                posaljiFrm(this);
                                prijava(k1);
                                frmKupac.Show();
                                this.Hide();
                                prikaz = false;
                            }
                            else
                            {
                                MessageBox.Show("Vaš nalog je obrisan od strane administratora.\nKontaktirajte korisnički servis za više informacija.", "Obrisan nalog", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                            
                        }
                        else if (a1 != null)
                        {
                            frmAdmin = new FormAdmin();
                            posaljiKorisnika prijava = FormAdmin.PrihvatiKorisnika;
                            prijava(a1);
                            frmAdmin.frmLogin = this;
                            frmAdmin.Show();
                            this.Hide();
                            prikaz = false;
                        }
                    }

                    break;
                }
            }
            if (!postoji)
            {
                MessageBox.Show("Uneli ste pogresno korisnicko ime ili lozinku!", "Pogresno uneti podaci", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UcitajBazu(object sender, EventArgs e)
        {
            //Ucitaj listu korisnika iz fajlova.
            LocalFileManager lfm = new LocalFileManager(); //Ucitava osnovnu listu korisnika (..\data\default.csv)
            listaKorisnika = lfm.UserCSVRead();
            Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") +" "+ "[UPOZORENJE]: Ucitana je baza osnovnih naloga!");

            //Ucitavanje korisnika iz JSON fajlova
            LocalFileManager.JSONDeserialize(listaKorisnika, "administratori");
            LocalFileManager.JSONDeserialize(listaKorisnika, "kupci");

        }

        //Poziva prijavu korisnika, ako je uspesno prijavljivanje, ova forma se sakriva.
        private void prijava(object sender, EventArgs e)
        {
            prijaviKorisnika(txtUsername.Text, txtPassword.Text);
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
                prikaz = true;
            }
        }

        private void zabLozinka(object sender, EventArgs e)
        {
            if (!txtUsername.Text.Equals("markod") && !txtUsername.Text.Equals("admin") && !txtUsername.Text.Equals("dujovicm@gmail.com"))
            {
                frmReset = new FormLozinkaReset();
                posaljiFrm = new posaljiFormu(frmReset.prihvatiFormu);
                posaljiFrm(this);
                this.Hide();
                prikaz = false;
                frmReset.Show();
            }
            else
            {
                MessageBox.Show("Sifra se ne moze resetovati za podrazumenvane naloge!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
