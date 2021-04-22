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
                novaProjekcija = new Projekcija(comboFilm.SelectedItem.ToString(), comboSala.SelectedIndex + 1, dateTimePicker1.Value, timeVreme.Value, double.Parse(txtCena.Text));
                LocalFileManager.JSONSerialize(novaProjekcija, "projekcije");

                this.Dispose();
                this.Close();
            }
        }
    }
}
