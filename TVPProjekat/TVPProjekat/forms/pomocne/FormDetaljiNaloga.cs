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

namespace TVPProjekat.forms.pomocne
{
    public partial class FormDetaljiNaloga : Form
    {
        private delegate void odjava(object sender, EventArgs e);
        private static Korisnik infoKorisnik;
        private FormKupac frmKupac;
        public FormDetaljiNaloga()
        {
            InitializeComponent();
        }

        private void otkljucajMenjanjeInformacija(object sender, EventArgs e)
        {
            if (this.chkOtkljucaj.Checked)
            {
                if (infoKorisnik.KorisnickoIme != "markod") //Default nalog, ne moze da se obrise ili izmeni
                {
                    txtEmail.Enabled = true;
                    txtIme.Enabled = true;
                    txtPrezime.Enabled = true;
                    txtTelefon.Enabled = true;
                    txtNovaLozinka.Enabled = true;
                    txtPonovnaLozinka.Enabled = true;
                    comboPol.Enabled = true;
                    dateDatum.Enabled = true;
                    btnPrihvati.Enabled = true;
                    btnObrisiNalog.Enabled = true;
                }
            }
            else
            {
                txtEmail.Enabled = false;
                txtIme.Enabled = false;
                txtPrezime.Enabled = false;
                txtTelefon.Enabled = false;
                txtNovaLozinka.Enabled = false;
                txtPonovnaLozinka.Enabled = false;
                comboPol.Enabled = false;
                dateDatum.Enabled = false;
                btnPrihvati.Enabled = false;
                btnObrisiNalog.Enabled = false;
            }
        }



        public static void prihvatiKorisnika(Korisnik korisnik)
        {
            infoKorisnik = korisnik;
        }

        public void prihvatiFormu(FormKupac formKupac)
        {
            frmKupac = formKupac;
        }

        private void ucitaj(object sender, EventArgs e)
        {
            lblIme.Text = infoKorisnik.Ime;
            lblPrezime.Text = infoKorisnik.Prezime;
            lblEmail.Text = infoKorisnik.Email;
            lblKorisnickoIme.Text = infoKorisnik.KorisnickoIme;
            lblTelefon.Text = infoKorisnik.Telefon;
            lblDatumRodjenja.Text = infoKorisnik.DatumRodjenja.ToString("dd/MM/yyyy");
            lblPol.Text = infoKorisnik.StrPol();
            if (infoKorisnik.KorisnickoIme.Equals("markod"))
            {
                chkOtkljucaj.Enabled = false; //Blokira izmene default naloga za kupca
            }
        }

        private void zatvori(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void obrisiNalog(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Da li stvarno zelite da obrisete nalog?", "Brisanje naloga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (msg == DialogResult.Yes)
            {
                odjava odjaviSe = new odjava(frmKupac.btnOdjava_Click);
                LocalFileManager.JSONDelete(infoKorisnik);
                this.Dispose();
                this.Close();
                odjaviSe(sender, e);
                MessageBox.Show("Vas nalog je uspesno obrisan");
                
            }
        }

        private void btnPrihvati_Click(object sender, EventArgs e)
        {
            if (ProveraForme.proveraImena(txtIme.Text) && ProveraForme.proveraImena(txtPrezime.Text) && ProveraForme.proveraEMaila(txtEmail.Text) && ProveraForme.proveraBrojaTelefona(txtTelefon.Text) && ProveraForme.proveraDatumaRodjenja(dateDatum.Value) && ProveraForme.proveraSifre(txtNovaLozinka.Text) && (txtPonovnaLozinka.Text.Equals(txtNovaLozinka.Text)) && ProveraForme.proveraPola(comboPol.SelectedIndex))
            {
                infoKorisnik.Ime = txtIme.Text;
                infoKorisnik.Prezime = txtPrezime.Text;
                infoKorisnik.Email = txtEmail.Text;
                infoKorisnik.Telefon = txtTelefon.Text;
                infoKorisnik.DatumRodjenja = dateDatum.Value;
                infoKorisnik.Pol = comboPol.SelectedIndex;
                infoKorisnik.Sifra = Korisnik.sifrujLozinku(txtNovaLozinka.Text);
            }
        }
    }
}