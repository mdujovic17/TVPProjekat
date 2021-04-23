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
    public partial class FormIzmenaSala : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        FormAdmin frmAdmin;
        Sala salaZaIzmenu;
        public FormIzmenaSala()
        {
            InitializeComponent();
        }
        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }

        public void prihvatiSalu(Sala sala)
        {
            salaZaIzmenu = sala;
        }

        private void potvrdiIzmene(object sender, EventArgs e)
        {
            if (/**/true) //TODO: Provera
            {
                salaZaIzmenu.BrojSale = int.Parse(txtBrojSale.Text);
                salaZaIzmenu.UkupanBrojSedista = int.Parse(txtBrojSedista.Text);

                LocalFileManager.JSONSerialize(salaZaIzmenu, "sale");

                prikaz = new prikaziIzmeneNaListi(frmAdmin.listUpdate);
                azuriraj = new azurirajPrikaz(frmAdmin.viewUpdate);

                prikaz();
                azuriraj(sender, e);

                this.Dispose();
                this.Close();
            }
        }

        private void popuniFormu(object sender, EventArgs e)
        {
            txtBrojSedista.Text = salaZaIzmenu.UkupanBrojSedista.ToString();
            txtBrojSale.Text = salaZaIzmenu.BrojSale.ToString();
            txtID.Text = salaZaIzmenu.Uid;
        }

        private void otkaziIzmene(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }

    
}
