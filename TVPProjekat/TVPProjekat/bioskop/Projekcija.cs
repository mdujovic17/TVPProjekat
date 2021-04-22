using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.bioskop
{
    [DataContract]
    class Projekcija
    {
        [DataMember]
        private string film;
        [DataMember]
        private int sala;
        [DataMember]
        private DateTime datumProjekcije;
        [DataMember]
        private DateTime vremeProjekcije;
        [DataMember]
        private double cenaKarte;
        [DataMember]
        private string uid;

        //Kreiranje nove projekcije
        public Projekcija(string film, int sala, DateTime datumProjekcije, DateTime vremeProjekcije, double cenaKarte)
        {
            this.Uid = generateUID();
            this.Film = film;
            this.Sala = sala;
            this.DatumProjekcije = datumProjekcije;
            this.VremeProjekcije = vremeProjekcije;
            this.CenaKarte = cenaKarte;
        }

        public Projekcija(string uid, string film, int sala, DateTime datumProjekcije, DateTime vremeProjekcije, double cenaKarte)
        {
            this.Uid = uid;
            this.Film = film;
            this.Sala = sala;
            this.DatumProjekcije = datumProjekcije;
            this.VremeProjekcije = vremeProjekcije;
            this.CenaKarte = cenaKarte;
        }

        public DateTime DatumProjekcije { get => datumProjekcije; set => datumProjekcije = value; }
        public DateTime VremeProjekcije { get => vremeProjekcije; set => vremeProjekcije = value; }
        public double CenaKarte { get => cenaKarte; set => cenaKarte = value; }
        public string Uid { get => uid; set => uid = value; }
        internal string Film { get => film; set => film = value; }
        internal int Sala { get => sala; set => sala = value; }

        private string generateUID()
        {
            Random random = new Random();

            return random.Next(10000,99999).ToString();
        }
    }
}
