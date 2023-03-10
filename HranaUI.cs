using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class HranaUI
    {
        public static void MeniHrana()
        {
            Meni meniHrana = new Meni();
            meniHrana.DodajOpciju(UpitZaIspis, "Ispisi svu hranu");
            meniHrana.DodajOpciju(Unos, "Unos nove hrane");
            meniHrana.DodajOpciju(Brisanje, "Brisanje hrane");
            meniHrana.DodajOpciju(TipoviUI.MeniTipHrane, "Tipovi Hrane");
            meniHrana.Pokreni();
        }
        // dodati meni za ispis hrane po rednom broju ili po abecednom redu naziva
        public static void UpitZaIspis()
        {
            Meni meniSort = new Meni();
            meniSort.DodajOpciju(IspisID, "Ispis hrane sortirane po ID broju");
            meniSort.DodajOpciju(IspisIDDesc, "Ispis hrane sortirane po ID broju obrnuto");
            meniSort.DodajOpciju(IspisABC, "Ispis hrane po abecednom redu");
            meniSort.DodajOpciju(IspisABCDesc, "Ispis hrane po abecednom redu obrnuto");
            meniSort.DodajOpciju(Ispis, "Ispisi uobicajeno");
            meniSort.Pokreni();
        }
        public static void IspisABC()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => p.Naziv.CompareTo(q.Naziv));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Hrana)
                    Console.WriteLine(art);
            }
        }
        public static void IspisID()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => p.Id.CompareTo(q.Id));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Hrana)
                    Console.WriteLine(art);
            }
        }
        public static void IspisABCDesc()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => q.Naziv.CompareTo(p.Naziv));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Hrana)
                    Console.WriteLine(art);
            }
        }
        public static void IspisIDDesc()
        {
            List<Artikl> sortiraniArtikli = Kolekcije.listaArtikala;
            sortiraniArtikli.Sort((p, q) => q.Id.CompareTo(p.Id));
            foreach (Artikl art in sortiraniArtikli)
            {
                if (art is Hrana)
                    Console.WriteLine(art);
            }
        }
        public static void Ispis()
        {
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a is Hrana)
                    Console.WriteLine(a);
            }
        }
        public static void Unos()
        {
            Console.WriteLine($"Upisivanje nove hrane pod sifrom: {Artikl.brojacId} . . .\n");
            Console.WriteLine("Unesite naziv hrane:");
            string noviNaziv = Console.ReadLine();
            Console.WriteLine("Unesite tip hrane (1 - predjelo,  2 - glavno jelo, 3 - dezert):");
            TipHrane noviTip = GetTipHrane(int.Parse(Console.ReadLine()));
            Console.WriteLine("Unesite cenu hrane: ");
            double novaCena = double.Parse(Console.ReadLine());
            Kolekcije.listaArtikala.Add(new Hrana(noviNaziv, noviTip, novaCena));
            Bojadisanje.UspesnaBoja($"Hrana {noviNaziv} uspesno dodata.");
        }
        public static TipHrane GetTipHrane(int idTipa)
        {
            TipHrane tempTip = null;
            foreach (TipHrane th in Kolekcije.listaTipova)
            {
                if (th.Id == idTipa)
                {
                    tempTip = th;
                }
            }
            return tempTip;
        }
        public static void Brisanje()
        {
            Console.WriteLine("Unesite ID hrane koju zelite obrisati:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a is Hrana && a.Id == idZaBrisanje)
                {
                    Kolekcije.listaArtikala.Remove(a);
                    Bojadisanje.GresnaBoja($"Hrana sa ID brojem {idZaBrisanje} je uspesno obrisana.");
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
                        if (a is Hrana)
                            sw.WriteLine(((Hrana)a).ToFileString());
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
                        int idHrane = int.Parse(tokeni[0]);
                        string naziv = tokeni[1];
                        TipHrane tip = GetTipHrane(int.Parse(tokeni[3]));
                        double cena = double.Parse(tokeni[2]);
                        Kolekcije.listaArtikala.Add(new Hrana(naziv, tip, cena, idHrane));
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
