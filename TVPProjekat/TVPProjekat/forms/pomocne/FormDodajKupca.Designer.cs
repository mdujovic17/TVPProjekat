
namespace TVPProjekat.forms.pomocne
{
    partial class FormDodajKupca
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblSifra = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblKorIme = new System.Windows.Forms.Label();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.lblPol = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.comboPol = new System.Windows.Forms.ComboBox();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblIme = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(202, 257);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 23);
            this.btnClear.TabIndex = 56;
            this.btnClear.Text = "Obriši formu";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.clear);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(12, 257);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(158, 23);
            this.btnDodaj.TabIndex = 55;
            this.btnDodaj.Text = "Dodaj kupca";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.dodajNovogKupca);
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(9, 215);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 54;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(12, 231);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(348, 20);
            this.txtTelefon.TabIndex = 53;
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(9, 173);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(28, 13);
            this.lblSifra.TabIndex = 52;
            this.lblSifra.Text = "Šifra";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(12, 189);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(348, 20);
            this.txtSifra.TabIndex = 51;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 134);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 50;
            this.lblEmail.Text = "E-Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 150);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(348, 20);
            this.txtEmail.TabIndex = 49;
            // 
            // lblKorIme
            // 
            this.lblKorIme.AutoSize = true;
            this.lblKorIme.Location = new System.Drawing.Point(9, 95);
            this.lblKorIme.Name = "lblKorIme";
            this.lblKorIme.Size = new System.Drawing.Size(75, 13);
            this.lblKorIme.TabIndex = 48;
            this.lblKorIme.Text = "Korisničko ime";
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(12, 111);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(348, 20);
            this.txtKorisnickoIme.TabIndex = 47;
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(245, 52);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(22, 13);
            this.lblPol.TabIndex = 46;
            this.lblPol.Text = "Pol";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(9, 52);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(77, 13);
            this.lblDatum.TabIndex = 45;
            this.lblDatum.Text = "Datum rođenja";
            // 
            // comboPol
            // 
            this.comboPol.FormattingEnabled = true;
            this.comboPol.Items.AddRange(new object[] {
            "M",
            "Ž"});
            this.comboPol.Location = new System.Drawing.Point(248, 67);
            this.comboPol.Name = "comboPol";
            this.comboPol.Size = new System.Drawing.Size(112, 21);
            this.comboPol.TabIndex = 44;
            // 
            // dateDatum
            // 
            this.dateDatum.Location = new System.Drawing.Point(12, 68);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.Size = new System.Drawing.Size(230, 20);
            this.dateDatum.TabIndex = 43;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(186, 8);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(44, 13);
            this.lblPrezime.TabIndex = 42;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(9, 8);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(24, 13);
            this.lblIme.TabIndex = 41;
            this.lblIme.Text = "Ime";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(189, 24);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(171, 20);
            this.txtPrezime.TabIndex = 40;
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 24);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(171, 20);
            this.txtIme.TabIndex = 39;
            // 
            // FormDodajKupca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 294);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblKorIme);
            this.Controls.Add(this.txtKorisnickoIme);
            this.Controls.Add(this.lblPol);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.comboPol);
            this.Controls.Add(this.dateDatum);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Name = "FormDodajKupca";
            this.Text = "FormDodajKorisnika";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblKorIme;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.ComboBox comboPol;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.TextBox txtIme;
    }
}