using RestoranDomaci.Interfejsi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class PiceUI : IReadWriteDeletable
    {
        public static void Ispis()
        {
            foreach (Pice p in Kolekcije.listaArtikala)
            {
                if (p is Pice)
                    Console.WriteLine(p);
            }
        }
        public static void Unos()
        {
            Console.WriteLine($"Upisivanje novog pica pod sifrom: {Artikl.brojacId} . . .\n");
            Console.WriteLine("Unesite naziv pica:");
            string noviNaziv = Console.ReadLine();
            Console.WriteLine("Unesite zapreminu pica:");
            double novaZapremina = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite cenu pica: ");
            double novaCena = double.Parse(Console.ReadLine());
            Kolekcije.listaArtikala.Add(new Pice(noviNaziv, novaZapremina, novaCena));
            Bojadisanje.UspesnaBoja($"Pice {noviNaziv} uspesno dodato.");
        }
        public static void Brisanje()
        {
            Console.WriteLine("Unesite ID pica koje zelite obrisati:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            foreach (Pice p in Kolekcije.listaArtikala)
            {
                if (p.Id == idZaBrisanje && p is Pice)
                {
                    Kolekcije.listaArtikala.Remove(p);
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
                    foreach (Pice p in Kolekcije.listaArtikala)
                    {
                        sw.WriteLine(p.ToFileString());
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
                        Kolekcije.listaArtikala.Add(new Pice(tokeni[0], double.Parse(tokeni[1]), double.Parse(tokeni[2]), int.Parse(tokeni[3])));
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
