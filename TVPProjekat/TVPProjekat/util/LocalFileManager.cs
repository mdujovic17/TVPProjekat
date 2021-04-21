using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    /*
     * Klasa za upravljanje fajlovima. Ima mogucnost pravljenja, citanja i pisanja fajlove CSV i JSON
     * datoteka.
     * CSV fajl je vrsta tekstualnog spreadsheet fajla ciji se podaci razdvajaju zarezom, tabulatorom 
     * ili znakom tacka-zarez, u zavisnosti od potrebe i formata podataka. Ovim formatom se omogucava
     * da ne samo ovaj program moze da otvori ovaj format, nego i drugi programi koji podrzavaju CSV,
     * kao sto su Excel, LibreOffice Calc itd. 
     * 
     * JSON je format otvorenog standarda koji koristi citljiv tekst za cuvanje i prenos podataka koji
     * su sacinjeni od atribut:vrednost parova.
     */
    class LocalFileManager
    {
        private static string folder = @"..\data\";
        private string fajl, ekstenzija;
        
        //Poziva podrazumevani fajl koji sadrzi osnovne korisnike
        public LocalFileManager()
        {
            this.fajl = "default";
            this.ekstenzija = "csv";

            string putanja = folder + @"\" + this.fajl + "." + this.ekstenzija;
        }

        //public LocalFileManager(string folder, string fajl, string ekstenzija)
        //{
        //    folder = folder;
        //    this.fajl = fajl;
        //    this.ekstenzija = ekstenzija;
        //}

        //Sluzi za citanje generisanih CSV fajlova
        public List<Korisnik> UserCSVRead()
        {
            List<Korisnik> lista = new List<Korisnik>();
            int brojRedova = 0;
            string linija = "";
            string[] podaci;
            StreamReader citac = new StreamReader(folder + @"\" + fajl + "." + ekstenzija);
            while ((linija = citac.ReadLine()) != null)
            {
                podaci = linija.Split(';');
                if (podaci.Count() == 10)
                {
                    if (bool.Parse(podaci[9]))
                    {
                        lista.Add(new Administrator(podaci[0], podaci[1], podaci[2], int.Parse(podaci[3]), podaci[4], podaci[5], podaci[6], podaci[7], DateTime.Parse(podaci[8]), bool.Parse(podaci[9])));
                    }
                    else
                    {
                        lista.Add(new Kupac(podaci[0], podaci[1], podaci[2], int.Parse(podaci[3]), podaci[4], podaci[5], podaci[6], podaci[7], DateTime.Parse(podaci[8]), bool.Parse(podaci[9])));
                    }
                }
                brojRedova++;
            }
            return lista;
        }

        /*Sluzi za serijalizaciju svih objekata. Prihvata parametar za objekat i parametar za ime foldera.
         Ograniceno je na objekte iz projekta.*/
        public static void JSONSerialize(object o, string folder)
        {
            FileStream fs;
            DataContractJsonSerializer serializer;
            string directoryPath = @"..\data\" + folder + @"\";
            switch (folder)
            {
                case "administratori":
                    fs = new FileStream(directoryPath + (o as Administrator).AdminUUID + ".json", FileMode.Create, FileAccess.ReadWrite);
                    serializer = new DataContractJsonSerializer(typeof(Administrator));
                    serializer.WriteObject(fs, o);
                    break;
                case "kupci":
                    fs = new FileStream(directoryPath + (o as Kupac).KupacUUID + ".json", FileMode.Create, FileAccess.ReadWrite);
                    serializer = new DataContractJsonSerializer(typeof(Kupac));
                    serializer.WriteObject(fs, o);
                    break;
                case "filmovi":
                    break;
                case "bioskopi":
                    break;
                default:
                    Debug.WriteLine(DateTime.Now.ToString("(HH: mm:ss)") + " " + $"[GRESKA]: Folder {folder} ne postoji!");
                    break;
            }
        }

        /* Koristi se za deserijalizaciju podataka tipa objekta Korisnik upisanih u JSON oblik.
         * Parametri: List<Korisnik> lista - Lista korisnika kojoj se dodaju deserijalizovani objekti
         *            string folder - Folder u kom se nalaze JSON podaci.
         */
        public static void JSONDeserialize(List<Korisnik> lista, string folder)
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\data\" + folder + @"\");
            FileInfo[] files = directory.GetFiles("*.json");
            FileStream fs; // = new FileStream(@"../data/administratori.json", FileMode.Open, FileAccess.Read);
            DataContractJsonSerializer serializer;// = new DataContractJsonSerializer(typeof());

            foreach (FileInfo file in files)
            {
                fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
                switch (folder)
                {
                    case "administratori":
                        serializer = new DataContractJsonSerializer(typeof(Administrator));
                        Administrator admin = (Administrator)serializer.ReadObject(fs);
                        lista.Add(admin);
                        Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {admin.AdminUUID} + sa lokacije {file.FullName}");
                        serializer = null;
                        break;
                    case "kupci":
                        serializer = new DataContractJsonSerializer(typeof(Kupac));
                        Kupac kupac = (Kupac)serializer.ReadObject(fs);
                        lista.Add(kupac);
                        Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {kupac.KupacUUID} + sa lokacije {file.FullName}");
                        break;
                    default:
                        break;
                }

            }
        }

        public static void JSONDeserialize(List<object> lista, string folder)
        {
            
            
            //while(fs.Position != fs.Length)
            //{
            //    Administrator admin = (Administrator)serializer.ReadObject(fs);
            //    Debug.WriteLine($"Deserijalizacija objekta: ${admin.AdminUUID}");
            //    lista.Add(admin);
            //}
        }

        //public static void UpisiXMLAdministratora(Administrator administrator)
        //{
        //    FileStream upisXML = new FileStream(@"../data/administratori.xml", FileMode.Append); //Ako ne postoji fajl, kreira ga
        //    SoapFormatter formattter = new SoapFormatter();

        //    formattter.Serialize(upisXML, administrator);

        //    upisXML.Flush(); upisXML.Close();
        //}

        //public static void CitajXMLAdmina(List<Korisnik> lista) 
        //{
        //    int brojac = 0; int temp = 1; long pos, len;
        //    FileStream citanjeXML = new FileStream(@"../data/administratori.xml", FileMode.Open, FileAccess.Read);
        //    //citanjeXML.Seek(0, SeekOrigin.Begin);
        //    SoapFormatter formatter = new SoapFormatter();
        //    pos = citanjeXML.Position;
        //    len = citanjeXML.Length;
        //    //List<Administrator> admini = new List<Administrator>();
        //    if (len != 0)
        //    {
        //        do
        //        {
        //            lista.Add((Administrator)formatter.Deserialize(citanjeXML));
        //            pos = citanjeXML.Position;
        //            //temp -= brojac;
        //            //brojac++;
        //        }
        //        while (citanjeXML.Position < citanjeXML.Length);
        //    }
            

        //    pos = citanjeXML.Position;

        //    citanjeXML.Flush(); citanjeXML.Close();
        //}
    }
}
