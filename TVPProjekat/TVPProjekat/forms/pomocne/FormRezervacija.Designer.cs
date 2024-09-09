﻿
namespace TVPProjekat.forms.pomocne
{
    partial class FormRezervacija
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvProjekcije = new System.Windows.Forms.ListView();
            this.clmImeFilma = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmTrajanje = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmCenaKarte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmDatumIVreme = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmSala = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBrojDostupnihSedista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numBrojMesta = new System.Windows.Forms.NumericUpDown();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.datePocetniDatum = new System.Windows.Forms.DateTimePicker();
            this.dateKrajniDatum = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboSale = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboNazivFilma = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numBrojMesta)).BeginInit();
            this.SuspendLayout();
            // 
            // lvProjekcije
            // 
            this.lvProjekcije.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmImeFilma,
            this.clmTrajanje,
            this.clmCenaKarte,
            this.clmDatumIVreme,
            this.clmSala,
            this.clmBrojDostupnihSedista});
            this.lvProjekcije.FullRowSelect = true;
            this.lvProjekcije.HideSelection = false;
            this.lvProjekcije.Location = new System.Drawing.Point(12, 89);
            this.lvProjekcije.Name = "lvProjekcije";
            this.lvProjekcije.Size = new System.Drawing.Size(682, 191);
            this.lvProjekcije.TabIndex = 0;
            this.lvProjekcije.UseCompatibleStateImageBehavior = false;
            this.lvProjekcije.View = System.Windows.Forms.View.Details;
            this.lvProjekcije.SelectedIndexChanged += new System.EventHandler(this.selektujObjekat);
            // 
            // clmImeFilma
            // 
            this.clmImeFilma.Text = "Film";
            this.clmImeFilma.Width = 201;
            // 
            // clmTrajanje
            // 
            this.clmTrajanje.Text = "Trajanje";
            this.clmTrajanje.Width = 57;
            // 
            // clmCenaKarte
            // 
            this.clmCenaKarte.Text = "Cena karte";
            this.clmCenaKarte.Width = 82;
            // 
            // clmDatumIVreme
            // 
            this.clmDatumIVreme.Text = "Datum i Vreme";
            this.clmDatumIVreme.Width = 145;
            // 
            // clmSala
            // 
            this.clmSala.Text = "Sala";
            this.clmSala.Width = 62;
            // 
            // clmBrojDostupnihSedista
            // 
            this.clmBrojDostupnihSedista.Text = "Broj dostupnih mesta";
            this.clmBrojDostupnihSedista.Width = 130;
            // 
            // numBrojMesta
            // 
            this.numBrojMesta.Location = new System.Drawing.Point(74, 287);
            this.numBrojMesta.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numBrojMesta.Name = "numBrojMesta";
            this.numBrojMesta.Size = new System.Drawing.Size(120, 20);
            this.numBrojMesta.TabIndex = 1;
            this.numBrojMesta.ValueChanged += new System.EventHandler(this.racunajCenu);
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(278, 287);
            this.txtCena.Name = "txtCena";
            this.txtCena.ReadOnly = true;
            this.txtCena.Size = new System.Drawing.Size(100, 20);
            this.txtCena.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ukupna cena";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Broj mesta";
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Location = new System.Drawing.Point(384, 285);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(236, 23);
            this.btnRezervisi.TabIndex = 5;
            this.btnRezervisi.Text = "Rezerviši";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.rezervisi);
            // 
            // datePocetniDatum
            // 
            this.datePocetniDatum.Location = new System.Drawing.Point(12, 25);
            this.datePocetniDatum.Name = "datePocetniDatum";
            this.datePocetniDatum.Size = new System.Drawing.Size(174, 20);
            this.datePocetniDatum.TabIndex = 7;
            // 
            // dateKrajniDatum
            // 
            this.dateKrajniDatum.Location = new System.Drawing.Point(192, 25);
            this.dateKrajniDatum.Name = "dateKrajniDatum";
            this.dateKrajniDatum.Size = new System.Drawing.Size(174, 20);
            this.dateKrajniDatum.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Početni datum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(189, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Krajnji datum";
            // 
            // comboSale
            // 
            this.comboSale.FormattingEnabled = true;
            this.comboSale.Location = new System.Drawing.Point(372, 24);
            this.comboSale.Name = "comboSale";
            this.comboSale.Size = new System.Drawing.Size(121, 21);
            this.comboSale.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Sala";
            // 
            // comboNazivFilma
            // 
            this.comboNazivFilma.FormattingEnabled = true;
            this.comboNazivFilma.Location = new System.Drawing.Point(500, 24);
            this.comboNazivFilma.Name = "comboNazivFilma";
            this.comboNazivFilma.Size = new System.Drawing.Size(194, 21);
            this.comboNazivFilma.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Naziv filma";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(12, 52);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(545, 31);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filtriraj prikaz";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.filtriraj);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(564, 52);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(130, 31);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Resetuj filter";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.resetFilter);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(626, 285);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(68, 23);
            this.btnOtkazi.TabIndex = 17;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.izadji);
            // 
            // FormRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 318);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboNazivFilma);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboSale);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateKrajniDatum);
            this.Controls.Add(this.datePocetniDatum);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.numBrojMesta);
            this.Controls.Add(this.lvProjekcije);
            this.Name = "FormRezervacija";
            this.Text = "FormRezervacija";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.zatvori);
            this.Load += new System.EventHandler(this.ucitajPodatke);
            ((System.ComponentModel.ISupportInitialize)(this.numBrojMesta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvProjekcije;
        private System.Windows.Forms.NumericUpDown numBrojMesta;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRezervisi;
        private System.Windows.Forms.DateTimePicker datePocetniDatum;
        private System.Windows.Forms.DateTimePicker dateKrajniDatum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboSale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboNazivFilma;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader clmImeFilma;
        private System.Windows.Forms.ColumnHeader clmTrajanje;
        private System.Windows.Forms.ColumnHeader clmCenaKarte;
        private System.Windows.Forms.ColumnHeader clmDatumIVreme;
        private System.Windows.Forms.ColumnHeader clmSala;
        private System.Windows.Forms.ColumnHeader clmBrojDostupnihSedista;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOtkazi;
    }
}