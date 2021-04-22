
namespace TVPProjekat.forms.pomocne
{
    partial class FormDodajFilm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboGodine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZanr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTrajanje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(12, 23);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(208, 20);
            this.txtIme.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ime filma";
            // 
            // comboGodine
            // 
            this.comboGodine.FormattingEnabled = true;
            this.comboGodine.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboGodine.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R",
            "NC-17"});
            this.comboGodine.Location = new System.Drawing.Point(98, 50);
            this.comboGodine.Name = "comboGodine";
            this.comboGodine.Size = new System.Drawing.Size(122, 21);
            this.comboGodine.TabIndex = 2;
            this.comboGodine.Text = "Odaberite granicu...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Granica godina";
            // 
            // txtZanr
            // 
            this.txtZanr.Location = new System.Drawing.Point(109, 94);
            this.txtZanr.Name = "txtZanr";
            this.txtZanr.Size = new System.Drawing.Size(111, 20);
            this.txtZanr.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Žanr";
            // 
            // txtTrajanje
            // 
            this.txtTrajanje.Location = new System.Drawing.Point(12, 94);
            this.txtTrajanje.Name = "txtTrajanje";
            this.txtTrajanje.Size = new System.Drawing.Size(91, 20);
            this.txtTrajanje.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trajanje (min)";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(12, 121);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(101, 23);
            this.btnPotvrdi.TabIndex = 8;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(119, 120);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(101, 23);
            this.btnOtkazi.TabIndex = 9;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // FormDodajFilm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 156);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTrajanje);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtZanr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboGodine);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIme);
            this.Name = "FormDodajFilm";
            this.Text = "FormDodajFilm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboGodine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtZanr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTrajanje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Button btnOtkazi;
    }
}