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
using TVPProjekat.bioskop;
using TVPProjekat.korisnik;

namespace TVPProjekat.forms.pomocne
{
    
    public partial class FormDetaljiRezervacije : Form
    {
        private Kupac kupac;
        private FormAdmin frmAdmin;
        List<Rezervacija> rezervacijeKupca;
        List<Projekcija> projekcije;
        Rezervacija selectedItem;
        public FormDetaljiRezervacije()
        {
            InitializeComponent();
            btnInvalidate.Enabled = false;
            rezervacijeKupca = new List<Rezervacija>();
            projekcije = new List<Projekcija>();
            LocalFileManager.JSONDeserialize(rezervacijeKupca, "rezervacije");
            LocalFileManager.JSONDeserialize(projekcije, "projekcije");
        }
        public void listUpdate()
        {
            rezervacijeKupca = new List<Rezervacija>();

            LocalFileManager.JSONDeserialize(rezervacijeKupca, "rezervacijce");
        }
        public void prihvatiKupca(Korisnik kupac)
        {
            this.kupac = kupac as Kupac;
        }
        public void prihvatiFormu(FormAdmin formAdmin)
        {
            frmAdmin = formAdmin;
        }
        private void selektujObjekat(object sender, EventArgs e)
        {
            string selektovanUUID = "";
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                selektovanUUID = item.SubItems[0].Text + "-" + item.SubItems[1].Text; //Uzima UUID
            }
            kontrola(selektovanUUID);

            if (selektovanUUID.Equals(""))
            {
                btnInvalidate.Enabled = false;
            }
            else
            {
                btnInvalidate.Enabled = true;
            }
        }
        private void kontrola(string uuid)
        {
            foreach (Rezervacija rezervacija in rezervacijeKupca)
            {
                if ((rezervacija.ProjekcijaID + "-" + rezervacija.KorisnickiID).Equals(uuid))
                {
                    selectedItem = rezervacija;
                    Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "Selektovan UUID: " + (rezervacija.KorisnickiID + "-" + rezervacija.ProjekcijaID));
                    break;
                }
            }
        }
        private void invalidateRezervacija(object sender, EventArgs e)
        {
            string uuid = uuid = selectedItem.KorisnickiID + "-" + selectedItem.ProjekcijaID;
            selectedItem.ProjekcijaID += "-1";
            foreach (Projekcija projekcija in projekcije)
            {
                if (projekcija.Uid.Equals(selectedItem.ProjekcijaID))
                {
                    projekcija.DostupnaMesta += selectedItem.BrojMesta;
                    LocalFileManager.JSONSerialize(projekcija, "projekcije");
                    break;
                }
            }
            LocalFileManager.JSONInvalidate(selectedItem, "rezervacije", uuid);
            listUpdate();
            ucitaj(sender, e);
        }

        private void izadji(object sender, EventArgs e)
        {
            frmAdmin.Show();
            this.Dispose();
            this.Close();
        }

        private void ucitaj(object sender, EventArgs e)
        {
            for (int i = 0; i < rezervacijeKupca.Count; i++)
            {
                if (!rezervacijeKupca[i].KorisnickiID.Equals(kupac.KupacUUID))
                {
                    rezervacijeKupca.RemoveAt(i);
                }
                if (rezervacijeKupca.Count != 0 && rezervacijeKupca != null)
                {
                    ListViewItem item = new ListViewItem(new[] { rezervacijeKupca[i].ProjekcijaID, rezervacijeKupca[i].KorisnickiID, rezervacijeKupca[i].Cena.ToString("0.00"), rezervacijeKupca[i].BrojMesta.ToString() });
                    listView1.Items.Add(item);
                }
                
            }
        }

        private void izadji(object sender, FormClosedEventArgs e)
        {
            frmAdmin.Show();
            this.Dispose();
            this.Close();
        }
    }
}
