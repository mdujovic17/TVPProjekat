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
        //List<Korisnik> lista;
        private bool validnost;
        private string invalidForm = "";
        Korisnik noviKorisnik;
        public FormRegistracija()
        {
            InitializeComponent();
            //lista = new List<Korisnik>();
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
                return true;
            }
            else return false;
        }
    }
}
