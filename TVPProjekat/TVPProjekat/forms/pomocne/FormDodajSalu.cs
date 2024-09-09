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
    public partial class FormDodajSalu : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        FormAdmin frmAdmin;

        Sala novaSala;
        public FormDodajSalu()
        {
            InitializeComponent();
        }
        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if ((txtBrojSale.Text != null && txtBrojSale.Text != "" && txtBrojSale.Text.Any(char.IsDigit)) && (txtBrojSedista.Text != null && txtBrojSedista.Text != "" && txtBrojSale.Text.Any(char.IsDigit)))
            {
                novaSala = new Sala(int.Parse(txtBrojSale.Text), int.Parse(txtBrojSedista.Text));
                LocalFileManager.JSONSerialize(novaSala, "sale");

                prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                prikaz();
                azuriraj(sender, e);

                this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
                this.Close();

                //MessageBox.Show("Potrebno je osveziti listu da bi ste videli izmene.", "Izmena podataka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
