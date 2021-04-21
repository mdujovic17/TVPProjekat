using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.korisnik
{
    [Serializable]
    public class Kupac : Korisnik
    {
        private string kupacUUID;
        private bool isAdmin;
        public string KupacUUID { get => kupacUUID; set => kupacUUID = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        //Za kreiranje novog kupca
        public Kupac(string ime, string prezime, int pol, string telefon, string email, string korisnickoIme, string sifra, DateTime datumRodjenja)
            : base(ime, prezime, pol, telefon, email, korisnickoIme, sifra, datumRodjenja, false)
        {
            this.Sifra = Korisnik.sifrujLozinku(Sifra);
            this.KupacUUID = generisiUUID();
            this.IsAdmin = false;
        }

        //Za ucitavanje kupca;
        public Kupac(string uuid, string ime, string prezime, int pol, string telefon, string email, string korisnickoIme, string sifra, DateTime datumRodjenja, bool isAdmin)
            : base(ime, prezime, pol, telefon, email, korisnickoIme, sifra, datumRodjenja, isAdmin)
        {
            this.KupacUUID = uuid;
            this.IsAdmin = isAdmin;
        }

        private string generisiUUID()
        {
            string uuid;
            Random rand = new Random();
            string dan = DateTime.Now.ToString("dd");
            string mesec = DateTime.Now.ToString("MM");
            string godina = DateTime.Now.ToString("yyyyy");
            string sat = DateTime.Now.ToString("HH");

            uuid = godina + mesec + dan + sat + "-" + rand.Next(17, 1717);

            return uuid;
        }

        public override string ToString()
        {
            return "UUID: " + KupacUUID + ", " + base.ToString();
        }
    }
}
