using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVPProjekat
{
    public partial class FormLogin : Form
    {
        FormRegistracija formaZaRegistraciju = new FormRegistracija();
        public FormLogin()
        {
            InitializeComponent();
        }

        private void otvoriRegistracionuFormu(object sender, EventArgs e)
        {
            formaZaRegistraciju.Show();
        }
    }
}
