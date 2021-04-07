
namespace TVPProjekat
{
    partial class frmLanding
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
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnKupac = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(12, 12);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(245, 53);
            this.btnAdmin.TabIndex = 0;
            this.btnAdmin.Text = "Administracija";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnKupac
            // 
            this.btnKupac.Location = new System.Drawing.Point(12, 71);
            this.btnKupac.Name = "btnKupac";
            this.btnKupac.Size = new System.Drawing.Size(245, 53);
            this.btnKupac.TabIndex = 1;
            this.btnKupac.Text = "Kupac";
            this.btnKupac.UseVisualStyleBackColor = true;
            // 
            // frmLanding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 136);
            this.Controls.Add(this.btnKupac);
            this.Controls.Add(this.btnAdmin);
            this.Name = "frmLanding";
            this.Text = "Projekat (Marko Dujovic, NRT-85/19)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnKupac;
    }
}

