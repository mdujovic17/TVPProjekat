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
    public partial class FormRegistracija : Form
    {
        List<Korisnik> listaKorisnika;
        List<Korisnik> listaAdmina;
        Korisnik noviKorisnik;
        public FormRegistracija()
        {
            
            InitializeComponent();
            dateDatum.MaxDate = DateTime.Now;
            listaKorisnika = new List<Korisnik>();
            listaAdmina = new List<Korisnik>();
            LocalFileManager.JSONDeserialize(listaKorisnika, "kupci");
            LocalFileManager.JSONDeserialize(listaAdmina, "administratori");
        }

        private void registrujKorisnika(object sender, EventArgs e)
        {
            if (proveraForme())
            {
                noviKorisnik = new Kupac(txtIme.Text, txtPrezime.Text, comboPol.SelectedIndex, txtTelefon.Text, txtEmail.Text, txtKorisnickoIme.Text, txtSifra.Text, dateDatum.Value);
                LocalFileManager.JSONSerialize(noviKorisnik, "kupci");
                MessageBox.Show("Uspesno ste registrovani.", "Registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool proveraForme()
        {
            if (ProveraForme.proveraImena(txtIme.Text) && ProveraForme.proveraImena(txtPrezime.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value) &&
                ProveraForme.proveraPola(comboPol.SelectedIndex) && ProveraForme.proveraKorImena(txtKorisnickoIme.Text) && ProveraForme.proveraEMaila(txtEmail.Text) && ProveraForme.proveraSifre(txtSifra.Text) &&
                ProveraForme.proveraBrojaTelefona(txtTelefon.Text) && ProveraForme.proveraCheckBoxa(chkUslovi))
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtIme.Clear();
            txtPrezime.Clear();
            txtEmail.Clear();
            txtKorisnickoIme.Clear();
            txtSifra.Clear();
            txtTelefon.Clear();
            chkUslovi.Checked = false;
        }
    }
}
