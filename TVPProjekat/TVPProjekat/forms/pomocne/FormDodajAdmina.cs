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

namespace TVPProjekat
{
    public partial class FormDodajAdmina : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        List<Korisnik> listaKorisnika;
        List<Korisnik> listaAdmina;

        FormAdmin frmAdmin;
        public FormDodajAdmina()
        {
            InitializeComponent();
            dateDatum.MaxDate = DateTime.Now;
            listaKorisnika = new List<Korisnik>();
            listaAdmina = new List<Korisnik>();
            LocalFileManager.JSONDeserialize(listaKorisnika, "kupci");
            LocalFileManager.JSONDeserialize(listaAdmina, "administratori");
        }
        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }
        private void clear(object sender, EventArgs e)
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtKorisnickoIme.Clear();
            txtSifra.Clear();
            txtTelefon.Clear();
        }

        private void dodajNovogAdmina(object sender, EventArgs e)
        {
            if (!proveraForme())
            {
                Administrator noviAdmin = new Administrator(txtIme.Text, txtPrezime.Text, comboPol.SelectedIndex, txtTelefon.Text, txtEmail.Text, txtKorisnickoIme.Text, txtSifra.Text, dateDatum.Value);
                LocalFileManager.JSONSerialize(noviAdmin, "administratori");

                prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                prikaz();
                azuriraj(sender, e);

                this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
                this.Close();

                //MessageBox.Show("Potrebno je osveziti listu da bi ste videli izmene.", "Izmena podataka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool proveraForme()
        {
            if (ProveraForme.proveraImena(txtIme.Text) && ProveraForme.proveraImena(txtPrezime.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value) &&
                ProveraForme.proveraPola(comboPol.SelectedIndex) && ProveraForme.proveraKorImena(txtKorisnickoIme.Text) && ProveraForme.proveraEMaila(txtEmail.Text) && ProveraForme.proveraSifre(txtSifra.Text) &&
                ProveraForme.proveraBrojaTelefona(txtTelefon.Text))
            {
                foreach (Korisnik korisnik in listaKorisnika)
                {
                    if (korisnik.KorisnickoIme.Equals(txtKorisnickoIme.Text))
                    {
                        MessageBox.Show("Korisnicko ime vec postoji!.", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (korisnik.Email.Equals(txtEmail.Text))
                    {
                        MessageBox.Show("EMail vec postoji!.", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                foreach (Korisnik korisnik1 in listaAdmina)
                {
                    if (korisnik1.KorisnickoIme.Equals(txtKorisnickoIme.Text))
                    {
                        MessageBox.Show("Korisnicko ime vec postoji!.", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    else if (korisnik1.Email.Equals(txtEmail.Text))
                    {
                        MessageBox.Show("EMail vec postoji!.", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return true;
            }
            else
                return false;
        }
    }
}
