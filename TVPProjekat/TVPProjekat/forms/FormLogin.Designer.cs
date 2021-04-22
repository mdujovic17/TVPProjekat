
namespace TVPProjekat
{
    partial class FormLogin
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.btnRegistracija = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblSifra = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(12, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(246, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(12, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(246, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btnPrijava
            // 
            this.btnPrijava.Location = new System.Drawing.Point(12, 93);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(119, 23);
            this.btnPrijava.TabIndex = 2;
            this.btnPrijava.Text = "Prijavite se";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.prijava);
            // 
            // btnRegistracija
            // 
            this.btnRegistracija.Location = new System.Drawing.Point(137, 93);
            this.btnRegistracija.Name = "btnRegistracija";
            this.btnRegistracija.Size = new System.Drawing.Size(121, 23);
            this.btnRegistracija.TabIndex = 3;
            this.btnRegistracija.Text = "Registracija";
            this.btnRegistracija.UseVisualStyleBackColor = true;
            this.btnRegistracija.Click += new System.EventHandler(this.otvoriRegistracionuFormu);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 6);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(116, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "E-Mail ili Korisničko ime";
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(9, 51);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(28, 13);
            this.lblSifra.TabIndex = 5;
            this.lblSifra.Text = "Šifra";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 129);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnRegistracija);
            this.Controls.Add(this.btnPrijava);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Name = "FormLogin";
            this.Text = "Prijava";
            this.Load += new System.EventHandler(this.UcitajBazu);
            this.Shown += new System.EventHandler(this.OsveziBazu);
            this.VisibleChanged += new System.EventHandler(this.OsveziBazu);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.Button btnRegistracija;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblSifra;
    }
}

