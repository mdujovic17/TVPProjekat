﻿using System;
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
    public partial class FormIzmenaFilm : Form
    {
        private delegate void prikaziIzmeneNaListi();
        private delegate void azurirajPrikaz(object sender, EventArgs e);
        prikaziIzmeneNaListi prikaz;
        azurirajPrikaz azuriraj;

        private Film filmZaIzmenu;
        private FormAdmin frmAdmin;
        public FormIzmenaFilm()
        {
            InitializeComponent();
        }
        public void prihvatiFormu(FormAdmin form)
        {
            frmAdmin = form;
        }

        public void prihvatiFilm(Film film)
        {
            filmZaIzmenu = film;
        }

        private void potvrdiIzmene(object sender, EventArgs e)
        {
            if (/**/true) //TODO: Provera
            {
                filmZaIzmenu.ImeFilma = txtIme.Text;
                filmZaIzmenu.Trajanje = int.Parse(txtTrajanje.Text);
                filmZaIzmenu.Zanr = txtZanr.Text;
                filmZaIzmenu.Granica = comboGodine.SelectedIndex;

                LocalFileManager.JSONSerialize(filmZaIzmenu, "filmovi");

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
            txtIme.Text = filmZaIzmenu.ImeFilma;
            txtTrajanje.Text = filmZaIzmenu.Trajanje.ToString();
            txtZanr.Text = filmZaIzmenu.Zanr;
            txtID.Text = filmZaIzmenu.Id;
            comboGodine.SelectedIndex = filmZaIzmenu.Granica;
        }

        private void otkaziIzmene(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
    }
}
