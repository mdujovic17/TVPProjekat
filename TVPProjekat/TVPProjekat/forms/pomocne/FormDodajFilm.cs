using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.bioskop;

namespace TVPProjekat.forms.pomocne
{
    public partial class FormDodajFilm : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        FormAdmin frmAdmin;

        private Film noviFilm;
        public FormDodajFilm()
        {
            InitializeComponent();
        }
        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }
        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if ((txtIme.Text != null || txtIme.Text != "") && (txtTrajanje.Text != null || txtTrajanje.Text != "") && (txtZanr.Text != null || txtZanr.Text != "") && comboGodine.SelectedIndex != -1)
            {
                noviFilm = new Film(txtIme.Text, txtZanr.Text, int.Parse(txtTrajanje.Text), comboGodine.SelectedIndex);
                LocalFileManager.JSONSerialize(noviFilm, "filmovi");

                prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                prikaz();
                azuriraj(sender, e);

                this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
                this.Close();

                MessageBox.Show("Potrebno je osveziti listu da bi ste videli izmene.", "Izmena podataka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
