
namespace TVPProjekat.forms.pomocne
{
    partial class FormLozinkaReset
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lvlProvera = new System.Windows.Forms.Label();
            this.txtProvera = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNovaLozinka = new System.Windows.Forms.TextBox();
            this.txtPonovoLozinka = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unesite vas E-Mail";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(12, 25);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(313, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // dateDatum
            // 
            this.dateDatum.CustomFormat = "dd/MM/yyyy";
            this.dateDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDatum.Location = new System.Drawing.Point(12, 68);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.ShowUpDown = true;
            this.dateDatum.Size = new System.Drawing.Size(313, 20);
            this.dateDatum.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unesite vas datum rodjenja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Unesite sledeci tekst: ";
            // 
            // lvlProvera
            // 
            this.lvlProvera.AutoSize = true;
            this.lvlProvera.Location = new System.Drawing.Point(133, 95);
            this.lvlProvera.Name = "lvlProvera";
            this.lvlProvera.Size = new System.Drawing.Size(35, 13);
            this.lvlProvera.TabIndex = 5;
            this.lvlProvera.Text = "label4";
            // 
            // txtProvera
            // 
            this.txtProvera.Location = new System.Drawing.Point(13, 112);
            this.txtProvera.Name = "txtProvera";
            this.txtProvera.Size = new System.Drawing.Size(312, 20);
            this.txtProvera.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nova lozinka";
            // 
            // txtNovaLozinka
            // 
            this.txtNovaLozinka.Location = new System.Drawing.Point(13, 156);
            this.txtNovaLozinka.Name = "txtNovaLozinka";
            this.txtNovaLozinka.Size = new System.Drawing.Size(312, 20);
            this.txtNovaLozinka.TabIndex = 8;
            // 
            // txtPonovoLozinka
            // 
            this.txtPonovoLozinka.Location = new System.Drawing.Point(12, 198);
            this.txtPonovoLozinka.Name = "txtPonovoLozinka";
            this.txtPonovoLozinka.Size = new System.Drawing.Size(312, 20);
            this.txtPonovoLozinka.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Ponovo unesite lozinku";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 227);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(111, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Resetuj lozinku";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.resetujLozinku);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(249, 227);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(75, 23);
            this.btnOtkazi.TabIndex = 12;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.otkazi);
            // 
            // FormLozinkaReset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 262);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.txtPonovoLozinka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNovaLozinka);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProvera);
            this.Controls.Add(this.lvlProvera);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDatum);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Name = "FormLozinkaReset";
            this.Text = "FormLozinkaReset";
            this.Load += new System.EventHandler(this.ucitavanje);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lvlProvera;
        private System.Windows.Forms.TextBox txtProvera;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNovaLozinka;
        private System.Windows.Forms.TextBox txtPonovoLozinka;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOtkazi;
    }
}