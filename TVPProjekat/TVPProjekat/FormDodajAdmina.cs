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
    public partial class FormDodajAdmina : Form
    {
        public FormDodajAdmina()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!(txtIme.Text.Equals("") && txtPrezime.Text.Equals("") && txtEmail.Text.Equals("") && txtKorisnickoIme.Text.Equals("") && comboPol.SelectedIndex.Equals(null) && txtTelefon.Text.Equals("") && txtSifra.Text.Equals("") && dateDatum.Value.Equals(null)))
            {
                Administrator noviAdmin = new Administrator(txtIme.Text, txtPrezime.Text, comboPol.SelectedIndex, txtTelefon.Text, txtEmail.Text, txtKorisnickoIme.Text, txtSifra.Text, dateDatum.Value);
                LocalFileManager.JSONSerialize(noviAdmin, "administratori");

                this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
                this.Close();
            }
        }
    }
}
