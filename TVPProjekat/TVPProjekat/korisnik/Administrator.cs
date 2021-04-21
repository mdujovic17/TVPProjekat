using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.korisnik
{
    [DataContract]
    public class Administrator : Korisnik
    {
        [DataMember]
        private string adminUUID;
        [DataMember]
        private bool isAdmin;

        public string AdminUUID { get => adminUUID; set => adminUUID = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        //Konstruktor za kreiranje novog administratora
        public Administrator(string ime, string prezime, int pol, string telefon, string email, string korisnickoIme, string sifra, DateTime datumRodjenja)
            : base(ime, prezime, pol, telefon, email, korisnickoIme, sifra, datumRodjenja, true)
        {
            this.Sifra = Korisnik.sifrujLozinku(sifra);
            this.AdminUUID = generisiUUID();
            this.IsAdmin = true;
        }

        //Konstruktor za ucitavanje administratora
        public Administrator(string uuid, string ime, string prezime, int pol, string telefon, string email, string korisnickoIme, string sifra, DateTime datumRodjenja, bool isAdmin)
            : base(ime, prezime, pol, telefon, email, korisnickoIme, sifra, datumRodjenja, isAdmin)
        {
            this.AdminUUID = uuid;
            this.IsAdmin = isAdmin;
        }

        public Administrator()
        {
            this.AdminUUID = "";
            this.IsAdmin = true;
        }

        private string generisiUUID()
        {
            string uuid;

            Random rand = new Random();
            string dan = DateTime.Now.ToString("dd");
            string mesec = DateTime.Now.ToString("MM");
            string godina = DateTime.Now.ToString("yyyyy");
            string milisekund = DateTime.Now.ToString("ff");
            string sekund = DateTime.Now.ToString("ss");
            string minut = DateTime.Now.ToString("mm");
            string sat = DateTime.Now.ToString("HH");

            uuid = godina + mesec + dan + sat + minut + sekund + milisekund + "-" + rand.Next(17, 1717);

            return uuid;
        }

        public override string ToString()
        {
            return "UUID: " + AdminUUID + ", " + base.ToString();
        }
    }
}
