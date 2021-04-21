using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    public partial class FormKupac : Form
    {
        private static Kupac prijavljenKupac;
        public FormKupac()
        {
            InitializeComponent();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        public static Korisnik PrihvatiKorisnika(Korisnik kupac)
        {
            return prijavljenKupac = kupac as Kupac;
        }
    }
}
