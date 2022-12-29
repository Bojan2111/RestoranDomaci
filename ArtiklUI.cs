using RestoranDomaci.Interfejsi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RestoranDomaci
{
    internal class ArtiklUI : IReadWriteDeletable
    {
        public static void Ispis()
        {
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                Console.WriteLine(a);
            }
        }
        public static void Unos()
        {
            Console.WriteLine($"Upisivanje novog artikla pod sifrom: {Artikl.brojacId} . . .\n");
            Console.WriteLine("Unesite naziv artikla:");
            string noviNaziv = Console.ReadLine();
            Console.WriteLine("Unesite cenu artikla: ");
            double novaCena = double.Parse(Console.ReadLine());
            Kolekcije.listaArtikala.Add(new Artikl(noviNaziv,novaCena));
            Bojadisanje.UspesnaBoja($"Artikl {noviNaziv} uspesno dodat.");
        }
        public static void Brisanje()
        {
            Console.WriteLine("Unesite ID artikla koji zelite obrisati:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a.Id == idZaBrisanje)
                {
                    Kolekcije.listaArtikala.Remove(a);
                    Bojadisanje.GresnaBoja($"Artikl sa ID brojem {idZaBrisanje} je uspesno obrisan.");
                    break;
                }
            }
            
        }
        public static void SacuvajUFajl(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter sw = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (Artikl a in Kolekcije.listaArtikala)
                    {
                        sw.WriteLine(a.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void Ucitavanje(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamReader sr = new StreamReader(adresa))
                {
                    string linija;
                    while ((linija = sr.ReadLine()) != null)
                    {
                        string[] tokeni = linija.Split(',');
                        Kolekcije.listaArtikala.Add(new Artikl(tokeni[0], double.Parse(tokeni[1]), int.Parse(tokeni[2])));
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
    }
}
