using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.bioskop
{
    [DataContract]
    class Film
    {
        public enum granicaGodina { G = 0, PG = 1, PG13 = 2, R = 3, NC17 = 4 };
        [DataMember]
        int granica;
        [DataMember]
        private string imeFilma, zanr, id;
        [DataMember]
        private int trajanje;

        public string ImeFilma { get => imeFilma; set => imeFilma = value; }
        public string Zanr { get => zanr; set => zanr = value; }
        public string Id { get => id; set => id = value; }
        public int Trajanje { get => trajanje; set => trajanje = value; }
        public int Granica { get => granica; set => granica = value; }

        //Za ucitavanje u bazu
        public Film(string id, string imeFilma, string zanr, int trajanje, int granicaGodina) 
        {
            this.ImeFilma = imeFilma;
            this.Zanr = zanr;
            this.Id = id;
            this.Trajanje = trajanje;
            this.Granica = granicaGodina;
        }

        public Film(string imeFilma, string zanr, int trajanje, int granicaGodina)
        {
            this.Id = generateID();
            this.ImeFilma = imeFilma;
            this.Zanr = zanr;
            this.Trajanje = trajanje;
            this.granica = granicaGodina;
        }

        private string generateID()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString();
        }
    }
}
