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
    public partial class FormIzmenaProjekcija : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        FormAdmin frmAdmin;
        Projekcija projekcijaZaIzmenu;
        List<Film> filmovi;
        List<Sala> sale;
        public FormIzmenaProjekcija()
        {
            filmovi = new List<Film>();
            sale = new List<Sala>();

            InitializeComponent();
            dateDatum.MinDate = DateTime.Now;

            LocalFileManager.JSONDeserialize(filmovi, "filmovi");
            LocalFileManager.JSONDeserialize(sale, "sale");

            foreach (Film film in filmovi)
            {
                comboFilm.Items.Add(film.ImeFilma);
            }

            foreach (Sala sala in sale)
            {
                comboSala.Items.Add("Sala " + sala.BrojSale);
            }
        }

        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }

        public void prihvatiProjekciju(Projekcija projekcija)
        {
            projekcijaZaIzmenu = projekcija;
        }

        private void potvrdiIzmene(object sender, EventArgs e)
        {
            if (comboSala.SelectedIndex != -1 && comboFilm.SelectedIndex != -1 && dateDatum.Value > DateTime.Now && double.Parse(txtCena.Text) > 0)
            {
                foreach (Film film in filmovi)
                {
                    if (film.ImeFilma == comboFilm.SelectedItem.ToString())
                    {
                        projekcijaZaIzmenu.Film = film;
                    }
                }
                //projekcijaZaIzmenu.Sala = comboSala.SelectedIndex + 1;
                projekcijaZaIzmenu.CenaKarte = double.Parse(txtCena.Text);
                foreach (Sala sala in sale)
                {
                    if (sala.BrojSale == int.Parse(comboSala.SelectedItem.ToString().Replace("Sala ", "")))
                    {
                        projekcijaZaIzmenu.Sala = sala;
                        projekcijaZaIzmenu.DostupnaMesta = sala.UkupanBrojSedista;
                    }
                }
                projekcijaZaIzmenu.DatumProjekcije = dateDatum.Value;
                projekcijaZaIzmenu.VremeProjekcije = timeVreme.Value;

                LocalFileManager.JSONSerialize(projekcijaZaIzmenu, "projekcije");

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
            comboFilm.SelectedItem = projekcijaZaIzmenu.Film.ImeFilma;
            
            comboSala.SelectedItem = "Sala " + projekcijaZaIzmenu.Sala.ToString();
            txtCena.Text = projekcijaZaIzmenu.CenaKarte.ToString("0.00");
            txtID.Text = projekcijaZaIzmenu.Uid;
            dateDatum.Value = projekcijaZaIzmenu.DatumProjekcije;
            timeVreme.Value = projekcijaZaIzmenu.VremeProjekcije;
        }

        private void otkaziIzmene(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
