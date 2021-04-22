using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.bioskop
{
    [DataContract]
    class Rezervacija
    {
        [DataMember]
        private string korisnickiID;
        [DataMember]
        private string projekcijaID;
        [DataMember]
        private int brojMesta;
        [DataMember]
        private double cena;

        public Rezervacija(string korisnickiID, string projekcijaID, int brojMesta, double cena)
        {
            this.KorisnickiID = korisnickiID;
            this.ProjekcijaID = projekcijaID;
            this.BrojMesta = brojMesta;
            this.Cena = cena;
        }

        public string KorisnickiID { get => korisnickiID; set => korisnickiID = value; }
        public string ProjekcijaID { get => projekcijaID; set => projekcijaID = value; }
        public int BrojMesta { get => brojMesta; set => brojMesta = value; }
        public double Cena { get => cena; set => cena = value; }
    }
}
