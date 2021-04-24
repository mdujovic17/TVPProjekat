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
        public FormDodajAdmina()
        {
            InitializeComponent();
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
            if (!(txtIme.Text.Equals("") && txtPrezime.Text.Equals("") && txtEmail.Text.Equals("") && txtKorisnickoIme.Text.Equals("") && comboPol.SelectedIndex.Equals(null) && txtTelefon.Text.Equals("") && txtSifra.Text.Equals("") && dateDatum.Value.Equals(null)) &&
                ProveraForme.proveraImena(txtIme.Text) && ProveraForme.proveraImena(txtPrezime.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value) &&
                ProveraForme.proveraPola(comboPol.SelectedIndex) && ProveraForme.proveraKorImena(txtKorisnickoIme.Text) && ProveraForme.proveraEMaila(txtEmail.Text) && ProveraForme.proveraSifre(txtSifra.Text) &&
                ProveraForme.proveraBrojaTelefona(txtTelefon.Text))
            {
                Administrator noviAdmin = new Administrator(txtIme.Text, txtPrezime.Text, comboPol.SelectedIndex, txtTelefon.Text, txtEmail.Text, txtKorisnickoIme.Text, txtSifra.Text, dateDatum.Value);
                LocalFileManager.JSONSerialize(noviAdmin, "administratori");

                this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
                this.Close();

                MessageBox.Show("Potrebno je osveziti listu da bi ste videli izmene.", "Izmena podataka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
