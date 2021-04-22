using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVPProjekat.util
{
    class ProveraForme
    {
        internal static bool proveraImena(string ime)
        {
            if (ime == "" || ime == null || ime.Any(char.IsDigit) || ime.Any(char.IsWhiteSpace))
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraPola(int pol)
        {
            if (pol != 1 && pol != 0)
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraDatumaRodjenja(DateTime date)
        {
            if (date >= DateTime.Now)
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraKorImena(string korisnickoIme)
        {
            if (korisnickoIme.Length > 25 || korisnickoIme.Length < 5 || korisnickoIme.Any(char.IsControl) || korisnickoIme.Any(char.IsSurrogate) || korisnickoIme.Any(char.IsWhiteSpace) || korisnickoIme.Any(char.IsPunctuation))
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraEMaila(string mail)
        {
            int brojac = 0;
            for (int i = 0; i < mail.Length; i++)
            {
                if (mail[i].Equals('@'))
                {
                    brojac++;
                }
            }

            if (brojac != 1 || mail.Any(char.IsControl) || mail.Any(char.IsSurrogate) || mail.Any(char.IsWhiteSpace))
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraSifre(string sifra)
        {
            if (sifra.Length > 25 || sifra.Length < 5 || sifra.Any(char.IsControl) || sifra.Any(char.IsSurrogate) || sifra.Any(char.IsWhiteSpace))
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraBrojaTelefona(string telefon)
        {
            if (!telefon.Any(char.IsDigit) || telefon.Length != 10)
            {
                return false;
            }
            else return true;
        }

        internal static bool proveraCheckBoxa(CheckBox check)
        {
            if (!check.Checked)
            {
                return false;
            }
            else return true;
        }
    }
}
