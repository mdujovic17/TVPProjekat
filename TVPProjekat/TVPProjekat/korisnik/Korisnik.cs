using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.korisnik
{
    [DataContract]
    public class Korisnik
    {
        [DataMember]
        private string ime, prezime, telefon, email, korisnickoIme, sifra;
        [DataMember]
        private int pol;
        [DataMember]
        private DateTime datumRodjenja;
        private bool admin;

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }
        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Sifra { get => sifra; set => sifra = value; }
        public int Pol { get => pol; set => pol = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public bool Admin { get => admin; set => admin = value; }

        public Korisnik(string ime, string prezime, int pol, string telefon, string email, string korisnickoIme, string sifra, DateTime datumRodjenja, bool admin)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.Pol = pol;
            this.Telefon = telefon;
            this.Email = email;
            this.KorisnickoIme = korisnickoIme;
            this.Sifra = sifra;
            this.DatumRodjenja = datumRodjenja;
            this.Admin = admin;
        }

        public static string sifrujLozinku(string sifra)
        {
            string sifrovanaLozinka = "";
            for (int i = 0; i < sifra.Length; i++)
            {
                if (char.IsUpper(sifra[i]))
                {
                    sifrovanaLozinka += (char)((sifra[i] + 3 - 65) % 26 + 65);
                }
                else if (char.IsLower(sifra[i]))
                {
                    sifrovanaLozinka += (char)((sifra[i] + 3 - 97) % 26 + 97);
                }
                else if (char.IsDigit(sifra[i]))
                {
                    sifrovanaLozinka += (char)((sifra[i] + 3 - 48) % 10 + 48);
                }
                else if (char.IsPunctuation(sifra[i]))
                {
                    sifrovanaLozinka += (char)((sifra[i] + 3 - 33) % 15 + 33);
                }
            }

            return sifrovanaLozinka;
        }

        public static string desifrujLozinku(string sifra)
        {
            string desifrovanaLozinka = "";
            for (int i = 0; i < sifra.Length; i++)
            {
                if (char.IsUpper(sifra[i]))
                {
                    desifrovanaLozinka += (char)((sifra[i] - (3 - 26) - 65) % 26 + 65);
                }
                else if (char.IsLower(sifra[i]))
                {
                    desifrovanaLozinka += (char)((sifra[i] - (3 - 26) - 97) % 26 + 97);
                }
                else if (char.IsDigit(sifra[i]))
                {
                    desifrovanaLozinka += (char)((sifra[i] - (3 - 10) - 48) % 10 + 48);
                }
                else if (char.IsPunctuation(sifra[i]))
                {
                    desifrovanaLozinka += (char)((sifra[i] - (3 - 15) - 33) % 15 + 33);
                }
            }
            return desifrovanaLozinka;
        }

        public string StrPol()
        {
            if (this.Pol == 0)
            {
                return "Muško";
            }
            else
            {
                return "Žensko";
            }
        }

        public override string ToString()
        {
            return "Ime:" + Ime + ", Prezime: " + Prezime + ", pol: " + Pol + ", telefon: " + Telefon + ", E-Mail" + Email + ", Sifra: " + Sifra + ", Datum Rodjenja: " + DatumRodjenja.ToString("dd/mm/yyyy") + ", Administrator: " + admin.ToString();
        }
    }
}
