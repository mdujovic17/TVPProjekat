using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TVPProjekat.korisnik;
using TVPProjekat.util;

namespace TVPProjekat.forms.pomocne
{
    
    public partial class FormLozinkaReset : Form
    {
        private FormLogin frmLogin;
        private List<Korisnik> korisnici;
        private List<Korisnik> admini;
        public FormLozinkaReset()
        {
            InitializeComponent();

            korisnici = new List<Korisnik>();
            admini = new List<Korisnik>();

            LocalFileManager.JSONDeserialize(korisnici, "kupci");
            LocalFileManager.JSONDeserialize(admini, "administratori");
        }

        public void prihvatiFormu(Form form)
        {
            frmLogin = form as FormLogin;
        }

        private void resetujLozinku(object sender, EventArgs e)
        {
            if (txtEmail.Text.Equals("dujovicm@gmail.com"))
            {
                MessageBox.Show("Sifra se ne moze resetovati za podrazumenvane naloge!", ":)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (!txtEmail.Text.Equals("") && ProveraForme.proveraEMaila(txtEmail.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value))
                {
                    if (!txtProvera.Text.Equals(lvlProvera.Text))
                    {
                        MessageBox.Show("Tekst za proveru nije tacan!", "Provera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Korisnik korisnik;
                        foreach (Kupac kupac in korisnici)
                        {
                            if (kupac.Email.Equals(txtEmail.Text))
                            {
                                if (kupac.DatumRodjenja.ToString("dd/MM/yyyy").Equals(dateDatum.Value.ToString("dd/MM/yyyy")))
                                {
                                    if (txtNovaLozinka.Text.Equals(txtPonovoLozinka.Text))
                                    {
                                        korisnik = kupac;
                                        (korisnik as Kupac).Sifra = Korisnik.sifrujLozinku(txtNovaLozinka.Text);
                                        LocalFileManager.JSONSerialize(korisnik, "kupci");
                                        MessageBox.Show("Uspesno resetovana lozinka");
                                        otkazi(sender, e);
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lozinke nisu iste!", "Provera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Niste uneli tacan datum rodjenja!", "Provera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                        foreach (Administrator administrator in admini)
                        {
                            if (administrator.Email.Equals(txtEmail.Text))
                            {
                                if (administrator.DatumRodjenja.ToString("dd/MM/yyyy").Equals(dateDatum.Value.ToString("dd/MM/yyyy")))
                                {
                                    if (txtNovaLozinka.Text.Equals(txtPonovoLozinka.Text) && ProveraForme.proveraSifre(txtNovaLozinka.Text))
                                    {
                                        korisnik = administrator;
                                        (korisnik as Administrator).Sifra = Korisnik.sifrujLozinku(txtNovaLozinka.Text);
                                        LocalFileManager.JSONSerialize(korisnik, "administratori");
                                        MessageBox.Show("Uspesno resetovana lozinka");
                                        otkazi(sender, e);
                                        break;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lozinke nisu iste!", "Provera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Niste uneli tacan datum rodjenja!", "Provera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                        }
                        
                    }
                }
            }
        }

        private void otkazi(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
            frmLogin.Show();
        }

        private void ucitavanje(object sender, EventArgs e)
        {
            Random random = new Random();
            lvlProvera.Text = random.Next(1000, 9999).ToString();
        }
    }
}
