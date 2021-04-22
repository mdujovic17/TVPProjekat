using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TVPProjekat.bioskop
{
    [DataContract]
    class Sala
    {
        [DataMember]
        private string uid;
        [DataMember]
        private int brojSale;
        [DataMember]
        private int ukupanBrojSedista;

        public Sala(int brojSale, int ukupanBrojSedista)
        {
            this.BrojSale = brojSale;
            this.UkupanBrojSedista = ukupanBrojSedista;
            this.uid = generateUID();
        }

        public Sala(string uid, int brojSale, int ukupanBrojSedista)
        {
            this.Uid = uid;
            this.BrojSale = brojSale;
            this.UkupanBrojSedista = ukupanBrojSedista;
        }

        private string generateUID()
        {
            Random random = new Random();
            return BrojSale.ToString() + "-" + random.Next(1, 50);
        }

        public string Uid { get => uid; set => uid = value; }
        public int BrojSale { get => brojSale; set => brojSale = value; }
        public int UkupanBrojSedista { get => ukupanBrojSedista; set => ukupanBrojSedista = value; }
    }
}
