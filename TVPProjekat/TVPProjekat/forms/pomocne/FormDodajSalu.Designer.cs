
namespace TVPProjekat.forms.pomocne
{
    partial class FormDodajSalu
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
            this.txtBrojSale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBrojSedista = new System.Windows.Forms.TextBox();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj sale";
            // 
            // txtBrojSale
            // 
            this.txtBrojSale.Location = new System.Drawing.Point(12, 22);
            this.txtBrojSale.Name = "txtBrojSale";
            this.txtBrojSale.Size = new System.Drawing.Size(47, 20);
            this.txtBrojSale.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Broj sedišta";
            // 
            // txtBrojSedista
            // 
            this.txtBrojSedista.Location = new System.Drawing.Point(68, 22);
            this.txtBrojSedista.Name = "txtBrojSedista";
            this.txtBrojSedista.Size = new System.Drawing.Size(100, 20);
            this.txtBrojSedista.TabIndex = 3;
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(12, 51);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 4;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(93, 51);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(75, 23);
            this.btnOtkazi.TabIndex = 5;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // FormDodajSalu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(182, 86);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.txtBrojSedista);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBrojSale);
            this.Controls.Add(this.label1);
            this.Name = "FormDodajSalu";
            this.Text = "FormDodajSalu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrojSale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBrojSedista;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Button btnOtkazi;
    }
}