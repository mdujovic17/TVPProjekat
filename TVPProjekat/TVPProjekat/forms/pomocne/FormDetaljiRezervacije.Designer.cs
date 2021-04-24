
namespace TVPProjekat.forms.pomocne
{
    partial class FormDetaljiRezervacije
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.clmIDProjekcije = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmIDKupca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmUkupnaCena = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmBrojSedista = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInvalidate = new System.Windows.Forms.Button();
            this.btnIzadji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIDProjekcije,
            this.clmIDKupca,
            this.clmUkupnaCena,
            this.clmBrojSedista});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 216);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.selektujObjekat);
            // 
            // clmIDProjekcije
            // 
            this.clmIDProjekcije.Text = "UID Projekcije";
            this.clmIDProjekcije.Width = 283;
            // 
            // clmIDKupca
            // 
            this.clmIDKupca.Text = "UUID Kupca";
            this.clmIDKupca.Width = 274;
            // 
            // clmUkupnaCena
            // 
            this.clmUkupnaCena.Text = "Ukupna cena rezervacije";
            this.clmUkupnaCena.Width = 141;
            // 
            // clmBrojSedista
            // 
            this.clmBrojSedista.Text = "Broj sedišta";
            this.clmBrojSedista.Width = 74;
            // 
            // btnInvalidate
            // 
            this.btnInvalidate.Location = new System.Drawing.Point(12, 235);
            this.btnInvalidate.Name = "btnInvalidate";
            this.btnInvalidate.Size = new System.Drawing.Size(107, 23);
            this.btnInvalidate.TabIndex = 1;
            this.btnInvalidate.Text = "Ponisti rezervaciju";
            this.btnInvalidate.UseVisualStyleBackColor = true;
            this.btnInvalidate.Click += new System.EventHandler(this.invalidateRezervacija);
            // 
            // btnIzadji
            // 
            this.btnIzadji.Location = new System.Drawing.Point(689, 235);
            this.btnIzadji.Name = "btnIzadji";
            this.btnIzadji.Size = new System.Drawing.Size(99, 23);
            this.btnIzadji.TabIndex = 2;
            this.btnIzadji.Text = "Izadji iz pregleda";
            this.btnIzadji.UseVisualStyleBackColor = true;
            this.btnIzadji.Click += new System.EventHandler(this.izadji);
            // 
            // FormDetaljiRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 270);
            this.Controls.Add(this.btnIzadji);
            this.Controls.Add(this.btnInvalidate);
            this.Controls.Add(this.listView1);
            this.Name = "FormDetaljiRezervacije";
            this.Text = "FormDetaljiRezervacije";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.izadji);
            this.Load += new System.EventHandler(this.ucitaj);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clmIDProjekcije;
        private System.Windows.Forms.ColumnHeader clmIDKupca;
        private System.Windows.Forms.ColumnHeader clmUkupnaCena;
        private System.Windows.Forms.ColumnHeader clmBrojSedista;
        private System.Windows.Forms.Button btnInvalidate;
        private System.Windows.Forms.Button btnIzadji;
    }
}