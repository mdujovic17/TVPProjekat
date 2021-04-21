
namespace TVPProjekat
{
    partial class FormRegistracija
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
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.comboPol = new System.Windows.Forms.ComboBox();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lblPol = new System.Windows.Forms.Label();
            this.txtKorisnickoIme = new System.Windows.Forms.TextBox();
            this.lblKorIme = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblSifra = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.chkUslovi = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 25);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(171, 20);
            this.txtIme.TabIndex = 0;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(189, 25);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(171, 20);
            this.txtPrezime.TabIndex = 1;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(9, 9);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(24, 13);
            this.lblIme.TabIndex = 2;
            this.lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(186, 9);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(44, 13);
            this.lblPrezime.TabIndex = 3;
            this.lblPrezime.Text = "Prezime";
            // 
            // dateDatum
            // 
            this.dateDatum.Location = new System.Drawing.Point(12, 69);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.Size = new System.Drawing.Size(230, 20);
            this.dateDatum.TabIndex = 4;
            // 
            // comboPol
            // 
            this.comboPol.FormattingEnabled = true;
            this.comboPol.Items.AddRange(new object[] {
            "M",
            "Ž"});
            this.comboPol.Location = new System.Drawing.Point(248, 68);
            this.comboPol.Name = "comboPol";
            this.comboPol.Size = new System.Drawing.Size(112, 21);
            this.comboPol.TabIndex = 5;
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(9, 53);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(77, 13);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Text = "Datum rođenja";
            // 
            // lblPol
            // 
            this.lblPol.AutoSize = true;
            this.lblPol.Location = new System.Drawing.Point(245, 53);
            this.lblPol.Name = "lblPol";
            this.lblPol.Size = new System.Drawing.Size(22, 13);
            this.lblPol.TabIndex = 7;
            this.lblPol.Text = "Pol";
            // 
            // txtKorisnickoIme
            // 
            this.txtKorisnickoIme.Location = new System.Drawing.Point(12, 112);
            this.txtKorisnickoIme.Name = "txtKorisnickoIme";
            this.txtKorisnickoIme.Size = new System.Drawing.Size(348, 20);
            this.txtKorisnickoIme.TabIndex = 8;
            // 
            // lblKorIme
            // 
            this.lblKorIme.AutoSize = true;
            this.lblKorIme.Location = new System.Drawing.Point(9, 96);
            this.lblKorIme.Name = "lblKorIme";
            this.lblKorIme.Size = new System.Drawing.Size(75, 13);
            this.lblKorIme.TabIndex = 9;
            this.lblKorIme.Text = "Korisničko ime";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(9, 135);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 13);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "E-Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 151);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(348, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(9, 174);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(28, 13);
            this.lblSifra.TabIndex = 13;
            this.lblSifra.Text = "Šifra";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(12, 190);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(348, 20);
            this.txtSifra.TabIndex = 12;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(9, 216);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(43, 13);
            this.lblTelefon.TabIndex = 15;
            this.lblTelefon.Text = "Telefon";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(12, 232);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.Size = new System.Drawing.Size(348, 20);
            this.txtTelefon.TabIndex = 14;
            // 
            // chkUslovi
            // 
            this.chkUslovi.AutoSize = true;
            this.chkUslovi.Location = new System.Drawing.Point(12, 258);
            this.chkUslovi.Name = "chkUslovi";
            this.chkUslovi.Size = new System.Drawing.Size(158, 17);
            this.chkUslovi.TabIndex = 16;
            this.chkUslovi.Text = "Prihvatam uslove korišćenja";
            this.chkUslovi.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(12, 281);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(158, 23);
            this.btnRegister.TabIndex = 17;
            this.btnRegister.Text = "Registruj se";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(202, 281);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Obriši formu";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(176, 281);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(20, 23);
            this.btnInfo.TabIndex = 19;
            this.btnInfo.Text = "?";
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // FormRegistracija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 317);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.chkUslovi);
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
            this.Name = "FormRegistracija";
            this.Text = "FormRegistracija";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.ComboBox comboPol;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lblPol;
        private System.Windows.Forms.TextBox txtKorisnickoIme;
        private System.Windows.Forms.Label lblKorIme;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.CheckBox chkUslovi;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInfo;
    }
}