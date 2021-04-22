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
using TVPProjekat.bioskop;
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

        //Sluzi za citanje generisanih CSV fajlova za korisnike
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
            string path = "";
            switch (folder)
            {
                case "administratori":
                    path = directoryPath + (o as Administrator).AdminUUID + ".json";
                    break;
                case "kupci":
                    path = directoryPath + (o as Kupac).KupacUUID + ".json";
                    break;
                case "filmovi":
                    path = directoryPath + (o as Film).Id + ".json";
                    break;
                case "sale":
                    path = directoryPath + (o as Sala).Uid + ".json";
                    break;
                case "projekcije":
                    path = directoryPath + (o as Projekcija).Uid + ".json";
                    break;
                case "rezervacije":
                    path = directoryPath + (o as Rezervacija).KorisnickiID + "-" + (o as Rezervacija).ProjekcijaID + ".json";
                    break;
                default:
                    Debug.WriteLine(DateTime.Now.ToString("(HH: mm:ss)") + " " + $"[GRESKA]: Folder {folder} ne postoji!");
                    break;
            }
            fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            serializer = new DataContractJsonSerializer(o.GetType());
            serializer.WriteObject(fs, o);
            fs.Flush(); fs.Close();
        }

        //Sluzi za invalidaciju serijalizovanog objekta. Ako se objekat invaliduje, njegov UUID se prvobitno postavlja na -1
        private static void JSONInvalidate(object o, string folder, string uuid)
        {
            FileStream fs;
            DataContractJsonSerializer serializer;
            if (uuid != "" && folder != "")
            {
                string directoryPath = @"..\data\" + folder + @"\";

                fs = new FileStream(directoryPath + uuid + ".json", FileMode.Create, FileAccess.ReadWrite);
                serializer = new DataContractJsonSerializer(o.GetType());
                serializer.WriteObject(fs, o);
                fs.Flush(); fs.Close();
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
                fs.Close();
            }
        }
        public static void JSONDeserialize(List<Sala> lista, string folder) 
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\data\" + folder + @"\");
            FileInfo[] files = directory.GetFiles("*.json");
            FileStream fs;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Sala));

            foreach (FileInfo fajl in files)
            {
                fs = new FileStream(fajl.FullName, FileMode.Open, FileAccess.Read);
                Sala sala = (Sala)serializer.ReadObject(fs);
                lista.Add(sala);
                Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {sala.Uid} + sa lokacije {fajl.FullName}");
                fs.Close();
            }
        }
        public static void JSONDeserialize(List<Film> lista, string folder) 
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\data\" + folder + @"\");
            FileInfo[] files = directory.GetFiles("*.json");
            FileStream fs;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Film));

            foreach (FileInfo fajl in files)
            {
                fs = new FileStream(fajl.FullName, FileMode.Open, FileAccess.Read);
                Film film = (Film)serializer.ReadObject(fs);
                lista.Add(film);
                Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {film.Id} + sa lokacije {fajl.FullName}");
                fs.Close();
            }
        }
        public static void JSONDeserialize(List<Projekcija> lista, string folder) 
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\data\" + folder + @"\");
            FileInfo[] files = directory.GetFiles("*.json");
            FileStream fs;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Projekcija));

            foreach (FileInfo fajl in files)
            {
                fs = new FileStream(fajl.FullName, FileMode.Open, FileAccess.Read);
                Projekcija projekcija = (Projekcija)serializer.ReadObject(fs);
                lista.Add(projekcija);
                Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {projekcija.Uid} + sa lokacije {fajl.FullName}");
                fs.Close();
            }
        }
        public static void JSONDeserialize(List<Rezervacija> lista, string folder) 
        {
            DirectoryInfo directory = new DirectoryInfo(@"..\data\" + folder + @"\");
            FileInfo[] files = directory.GetFiles("*.json");
            FileStream fs;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Rezervacija));

            foreach (FileInfo fajl in files)
            {
                fs = new FileStream(fajl.FullName, FileMode.Open, FileAccess.Read);
                Rezervacija rezervacija = (Rezervacija)serializer.ReadObject(fs);
                lista.Add(rezervacija);
                Debug.WriteLine(DateTime.Now.ToString("(HH:mm:ss)") + " " + $"[INFO]: Deserijalizacija objekta sa UUID: {rezervacija.KorisnickiID} - {rezervacija.ProjekcijaID} + sa lokacije {fajl.FullName}");
                fs.Close();
            }
        }

        //Brise fajl ciji se id podudara sa imenom fajla, ako je kupac, menja se UUID
        //parametar na -1, i time se obavestava korisnik da je njegov nalog obrisan.
        public static void JSONDelete(object o)
        {
            string folder = "";
            string uuid = "";
            if (o is Administrator)
            {
                folder = "administratori";
                uuid = (o as Administrator).AdminUUID;
            }
            else if (o is Film)
            {
                folder = "filmovi";
                uuid = (o as Film).Id;
            }
            else if (o is Sala)
            {
                folder = "sale";
                uuid = (o as Sala).Uid;
            }
            else if (o is Projekcija)
            {
                folder = "projekcije";
                uuid = (o as Projekcija).Uid;
            }
            else if (o is Kupac)
            {
                folder = "kupci";
                uuid = (o as Kupac).KupacUUID;
                (o as Kupac).KupacUUID = "-1";
                JSONInvalidate(o, folder, uuid);
            }

            if (folder != "" && uuid != "")
            {
                string[] file = Directory.GetFiles(@"../data/" + folder, uuid + ".json");
                foreach (string fajl in file)
                {
                    File.Delete(fajl);
                }
            }
        }
    }
}
