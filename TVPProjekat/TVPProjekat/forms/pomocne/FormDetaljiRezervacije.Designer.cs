
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
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmIDProjekcije,
            this.clmIDKupca,
            this.clmUkupnaCena,
            this.clmBrojSedista});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 222);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(776, 216);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            // FormDetaljiRezervacije
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listView1);
            this.Name = "FormDetaljiRezervacije";
            this.Text = "FormDetaljiRezervacije";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader clmIDProjekcije;
        private System.Windows.Forms.ColumnHeader clmIDKupca;
        private System.Windows.Forms.ColumnHeader clmUkupnaCena;
        private System.Windows.Forms.ColumnHeader clmBrojSedista;
    }
}