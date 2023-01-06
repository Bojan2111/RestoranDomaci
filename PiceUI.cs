using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestoranDomaci
{
    internal class PiceUI
    {
        public static void MeniPice()
        {
            Meni meniPice = new Meni();
            meniPice.DodajOpciju(UpitZaIspis, "Ispisi sva pica");
            meniPice.DodajOpciju(Unos, "Unos novog pica");
            meniPice.DodajOpciju(Brisanje, "Brisanje pica");
            meniPice.Pokreni();
        }
        public static void UpitZaIspis()
        {
            Meni meniPiceSort = new Meni();
            meniPiceSort.DodajOpciju(IspisID, "Ispis pica sortiranog po ID broju");
            meniPiceSort.DodajOpciju(IspisIDDesc, "Ispis pica sortiranog po ID broju obrnuto");
            meniPiceSort.DodajOpciju(IspisABC, "Ispis pica po abecednom redu");
            meniPiceSort.DodajOpciju(IspisABCDesc, "Ispis pica po abecednom redu obrnuto");
            meniPiceSort.DodajOpciju(Ispis, "Ispisi uobicajeno");
            meniPiceSort.Pokreni();
        }
        public static void IspisABC()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => p.Naziv.CompareTo(q.Naziv));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Pice)
                    Console.WriteLine(art);
            }
        }
        public static void IspisID()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => p.Id.CompareTo(q.Id));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Pice)
                    Console.WriteLine(art);
            }
        }
        public static void IspisABCDesc()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => q.Naziv.CompareTo(p.Naziv));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Pice)
                    Console.WriteLine(art);
            }
        }
        public static void IspisIDDesc()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => q.Id.CompareTo(p.Id));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Pice)
                    Console.WriteLine(art);
            }
        }
        public static void Ispis()
        {
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a is Pice)
                    Console.WriteLine(a);
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
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a is Pice && a.Id == idZaBrisanje)
                {
                    Kolekcije.listaArtikala.Remove(a);
                    Bojadisanje.GresnaBoja($"Pice sa ID brojem {idZaBrisanje} je uspesno obrisano.");
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
                        if (a is Pice)
                            sw.WriteLine(((Pice)a).ToFileString());
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
