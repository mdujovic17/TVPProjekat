
namespace TVPProjekat.forms.pomocne
{
    partial class FormIzmenaProjekcija
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboFilm = new System.Windows.Forms.ComboBox();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeVreme = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.comboSala = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateDatum = new System.Windows.Forms.DateTimePicker();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Film";
            // 
            // comboFilm
            // 
            this.comboFilm.FormattingEnabled = true;
            this.comboFilm.Location = new System.Drawing.Point(15, 142);
            this.comboFilm.Name = "comboFilm";
            this.comboFilm.Size = new System.Drawing.Size(201, 21);
            this.comboFilm.TabIndex = 22;
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(142, 209);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(75, 23);
            this.btnOtkazi.TabIndex = 21;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.otkaziIzmene);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(15, 209);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 20;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.potvrdiIzmene);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Cena karte";
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(143, 106);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(73, 20);
            this.txtCena.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Vreme projekcije";
            // 
            // timeVreme
            // 
            this.timeVreme.CustomFormat = "HH:mm";
            this.timeVreme.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeVreme.Location = new System.Drawing.Point(104, 46);
            this.timeVreme.Name = "timeVreme";
            this.timeVreme.ShowUpDown = true;
            this.timeVreme.Size = new System.Drawing.Size(112, 20);
            this.timeVreme.TabIndex = 16;
            this.timeVreme.Value = new System.DateTime(2021, 4, 22, 17, 45, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Sala";
            // 
            // comboSala
            // 
            this.comboSala.FormattingEnabled = true;
            this.comboSala.Location = new System.Drawing.Point(15, 105);
            this.comboSala.Name = "comboSala";
            this.comboSala.Size = new System.Drawing.Size(121, 21);
            this.comboSala.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Datum projekcije";
            // 
            // dateDatum
            // 
            this.dateDatum.CustomFormat = "dd:MM:yyyy";
            this.dateDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDatum.Location = new System.Drawing.Point(104, 12);
            this.dateDatum.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.dateDatum.Name = "dateDatum";
            this.dateDatum.ShowUpDown = true;
            this.dateDatum.Size = new System.Drawing.Size(112, 20);
            this.dateDatum.TabIndex = 12;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(15, 183);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(201, 20);
            this.txtID.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "ID Projekcije";
            // 
            // FormIzmenaProjekcija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 244);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboFilm);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeVreme);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboSala);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateDatum);
            this.Name = "FormIzmenaProjekcija";
            this.Text = "FormIzmenaProjekcija";
            this.Load += new System.EventHandler(this.popuniFormu);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboFilm;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker timeVreme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateDatum;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label6;
    }
}