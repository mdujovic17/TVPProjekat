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
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    public partial class FormAdmin : Form
    {
        public delegate void Osvezi(bool osvezi);

        private static Administrator admin;
        public Form frmLogin;
        private Form frmDodajAdmina;
        private List<Korisnik> administratori;
        private List<Korisnik> kupci;
        private Korisnik selectedItem;

        private string sifra;

        Osvezi osvezavanje = FormLogin.osvezi;

        public FormAdmin()
        {
            InitializeComponent();
            osvezavanje(true);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public static Korisnik PrihvatiKorisnika(Korisnik administrator)
        {
            admin = administrator as Administrator;
            Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "[INFO]: Prijavljivanje administratora sa UUID: " + admin.AdminUUID);
            return administrator;
        }

        private void loadAdminPanel(object sender, EventArgs e)
        {
            this.stripUser.Text += admin.Ime;
            this.stripStatus.Text += "Administrator";
        }

        private void btnShowAdmins_Click(object sender, EventArgs e)
        {
            administratori = new List<Korisnik>();

            if (this.lvAdminPrikaz.Columns.Count != 0)
            {
                for (int i = 0; i < this.lvAdminPrikaz.Columns.Count; i++)
                {
                    this.lvAdminPrikaz.Columns.RemoveAt(i);
                    this.lvAdminPrikaz.Items.Clear();
                    i--;
                }
            }

            this.lvAdminPrikaz.View = View.Details;

            this.lvAdminPrikaz.Columns.Add("UUID", 40);
            this.lvAdminPrikaz.Columns.Add("Ime", 80);
            this.lvAdminPrikaz.Columns.Add("Prezime", 80);
            this.lvAdminPrikaz.Columns.Add("Pol", 30);
            this.lvAdminPrikaz.Columns.Add("Telefon", 80);
            this.lvAdminPrikaz.Columns.Add("E-mail", 100);
            this.lvAdminPrikaz.Columns.Add("Korisnicko ime", 100);
            this.lvAdminPrikaz.Columns.Add("Sifra (E)", 100);
            this.lvAdminPrikaz.Columns.Add("Datum rodjenja", 100);

            LocalFileManager.JSONDeserialize(administratori, "administratori");

            foreach (Administrator administrator in administratori)
            {
                sifra = "";
                for (int j = 0; j < administrator.Sifra.Length; j++)
                {
                    sifra += "*";
                }
                ListViewItem item = new ListViewItem(new[] { administrator.AdminUUID, administrator.Ime, administrator.Prezime, administrator.StrPol(), administrator.Telefon, administrator.Email, administrator.KorisnickoIme, sifra, administrator.DatumRodjenja.ToString("dd/MM/yyyy") });

                this.lvAdminPrikaz.Items.Add(item);
            }
        }

        private void odjaviSe(object sender, EventArgs e)
        {
            admin = null;
            if (administratori != null)
            {
                this.administratori.Clear();
            }

            

            osvezavanje(false);

            frmLogin.Show();
            this.Dispose(); //Potrebno da bi se svi resursi ove forme oslobodili, u suprotnom izaziva StackOverflowExepction
            this.Close();
        }

        private void zatvoriProgram(object sender, FormClosedEventArgs e)
        {
            frmLogin.Close();
        }

        private void prikaziKorisnike(object sender, EventArgs e)
        {
            kupci = new List<Korisnik>();
            if (this.lvAdminPrikaz.Columns.Count != 0)
            {
                for (int i = 0; i < this.lvAdminPrikaz.Columns.Count; i++)
                {
                    this.lvAdminPrikaz.Columns.RemoveAt(i);
                    this.lvAdminPrikaz.Items.Clear();
                    i--;
                }
            }

            this.lvAdminPrikaz.View = View.Details;

            this.lvAdminPrikaz.Columns.Add("UUID", 40);
            this.lvAdminPrikaz.Columns.Add("Ime", 80);
            this.lvAdminPrikaz.Columns.Add("Prezime", 80);
            this.lvAdminPrikaz.Columns.Add("Pol", 30);
            this.lvAdminPrikaz.Columns.Add("Telefon", 80);
            this.lvAdminPrikaz.Columns.Add("E-mail", 90);
            this.lvAdminPrikaz.Columns.Add("Korisnicko ime", 100);
            this.lvAdminPrikaz.Columns.Add("Sifra (E)", 60);
            this.lvAdminPrikaz.Columns.Add("Datum rodjenja", 90);
            this.lvAdminPrikaz.Columns.Add("Rezervacije", 70);

            LocalFileManager.JSONDeserialize(kupci, "kupci");

            for (int i = 0; i < kupci.Count; i++)
            {
                if (kupci[i] is Administrator)
                {
                    kupci.Remove(kupci[i]);
                    i--;
                }
                else
                {
                    Kupac k = kupci[i] as Kupac;
                    sifra = "";
                    for (int j = 0; j < k.Sifra.Length; j++)
                    {
                        sifra += "*";
                    }
                    ListViewItem item = new ListViewItem(new[] { k.KupacUUID, k.Ime, k.Prezime, k.StrPol(), k.Telefon, k.Email, k.KorisnickoIme, sifra, k.DatumRodjenja.ToString("dd/MM/yyyy") });

                    this.lvAdminPrikaz.Items.Add(item);
                }
            }
        }

        private void selektujObjekat(object sender, EventArgs e)
        {
            this.statusUUID.Text = "Selektovan ID ";
            string selektovanUUID = "";
            foreach (ListViewItem item in this.lvAdminPrikaz.SelectedItems)
            {
                selektovanUUID = item.SubItems[0].Text; //Uzima UUID
            }

            this.statusUUID.Text += selektovanUUID;
            kontrola(selektovanUUID);

            if (selektovanUUID.Equals(""))
            {
                this.btnIzmeni.Enabled = false;
                this.btnObrisi.Enabled = false;
            }
            else
            {
                this.btnIzmeni.Enabled = true;
                this.btnObrisi.Enabled = true;
            }
        }

        private void dodajAdmina(object sender, EventArgs e)
        {
            frmDodajAdmina = new FormDodajAdmina();
            frmDodajAdmina.Show();
        }

        private void kontrola(string uuid)
        {
            if (uuid.Length == 20 || uuid.Length == 22)
            {
                foreach (Administrator admin in administratori)
                {
                    if (admin.AdminUUID.Equals(uuid))
                    {
                        this.selectedItem = admin;
                        Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "Selektovan UUID: " + admin.AdminUUID);
                        break;
                    }
                }
            }
            else if(uuid.Length == 14 || uuid.Length == 16)
            {
                foreach (Kupac kupac in kupci)
                {
                    if (kupac.KupacUUID.Equals(uuid))
                    {
                        this.selectedItem = kupac;
                        Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + "Selektovan UUID: " + kupac.KupacUUID);
                        break;
                    }
                }
            }
        }

        private void obrisiStavku(object sender, EventArgs e)
        {
            DialogResult konacno = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabranu stavku? Obrisane stavke ne mogu da se povrate!", "Brisanje", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (konacno == DialogResult.Yes)
            {
                LocalFileManager.JSONDelete(selectedItem);
                if (selectedItem is Administrator)
                {
                    btnShowAdmins_Click(sender, e);
                }
                else if (selectedItem is Kupac)
                {
                    prikaziKorisnike(sender, e);
                }
            }
        }

        private void izmeniOdabrano(object sender, EventArgs e)
        {
            if (selectedItem is Administrator)
            {

            }
            else if (selectedItem is Kupac)
            {

            }
        }
    }
}
