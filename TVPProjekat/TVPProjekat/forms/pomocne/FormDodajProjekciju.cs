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
    public partial class FormDodajProjekciju : Form
    {
        List<Sala> sale = new List<Sala>();
        List<Film> filmovi = new List<Film>();

        Projekcija novaProjekcija;
        public FormDodajProjekciju()
        {
            InitializeComponent();
            LocalFileManager.JSONDeserialize(sale, "sale");
            LocalFileManager.JSONDeserialize(filmovi, "filmovi");
            foreach(Film film in filmovi) { this.comboFilm.Items.Add(film.ImeFilma); }
            foreach (Sala sala in sale) { this.comboSala.Items.Add("Sala " + sala.BrojSale); }
        }

        private void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if ((this.txtCena.Text != null || txtCena.Text != "") && (this.comboFilm.SelectedIndex != -1) && (this.comboSala.SelectedIndex != -1))
            {
                Film film = null;
                int brojDosupnihMesta = 0;
                foreach (Film film1 in filmovi)
                {
                    if (film1.ImeFilma.Equals(comboFilm.SelectedItem.ToString()))
                    {
                        film = film1;
                        break;
                    }
                }
                foreach (Sala sala in sale)
                {
                    if ((comboSala.SelectedIndex + 1).ToString().Equals(sala.BrojSale.ToString()))
                    {
                        brojDosupnihMesta = sala.UkupanBrojSedista;
                    }
                }
                novaProjekcija = new Projekcija(film, comboSala.SelectedIndex + 1, brojDosupnihMesta, dateTimePicker1.Value, timeVreme.Value, double.Parse(txtCena.Text));
                LocalFileManager.JSONSerialize(novaProjekcija, "projekcije");

                this.Dispose();
                this.Close();
            }
        }
    }
}
