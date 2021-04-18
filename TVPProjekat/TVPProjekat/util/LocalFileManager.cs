using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TVPProjekat.korisnik;

namespace TVPProjekat
{
    /*
     * Klasa za upravljanje fajlovima. Ima mogucnost pravljenja, citanja i pisanja fajlove CSV formata.
     * CSV fajl je vrsta tekstualnog spreadsheet fajla ciji se podaci razdvajaju zarezom, tabulatorom 
     * ili znakom tacka-zarez, u zavisnosti od potrebe i formata podataka. Ovim formatom se omogucava
     * da ne samo ovaj program moze da otvori ovaj format, nego i drugi programi koji podrzavaju CSV,
     * kao sto su Excel, LibreOffice Calc itd. 
     */
    class LocalFileManager
    {
        private string folder, fajl, ekstenzija;
        
        //Poziva podrazumevani fajl koji sadrzi osnovne korisnike
        public LocalFileManager()
        {
            this.folder = @"..\data";
            this.fajl = "default";
            this.ekstenzija = "csv";

            string putanja = this.folder + @"\" + this.fajl + "." + this.ekstenzija;
            //DirectoryInfo dir = new DirectoryInfo(this.folder);
            //if (!fs.Exists) {
            //    MessageBox.Show("Fajl " + this.fajl + " ne postoji.");
            //    if (!dir.Exists)
            //    {
            //        Directory.CreateDirectory(folder);
            //    }
            //    fs.Create();
            //}
        }

        public LocalFileManager(string folder, string fajl, string ekstenzija)
        {
            this.folder = folder;
            this.fajl = fajl;
            this.ekstenzija = ekstenzija;
        }

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
                        lista.Add(new Administrator(podaci[0], podaci[1], podaci[2], int.Parse(podaci[3]), podaci[4], podaci[5], podaci[6], podaci[7], DateTime.Parse(podaci[8])));
                    }
                    else
                    {
                        lista.Add(new Kupac(podaci[0], podaci[1], podaci[2], int.Parse(podaci[3]), podaci[4], podaci[5], podaci[6], podaci[7], DateTime.Parse(podaci[8])));
                    }
                }
                brojRedova++;
            }
            return lista;
        }
    }
}
