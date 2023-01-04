using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class TipoviUI
    {
        public static void MeniTipHrane()
        {
            Meni meniTipHrane = new Meni();
            meniTipHrane.DodajOpciju(Ispis, "Ispisi sve tipove hrane");
            meniTipHrane.DodajOpciju(Unos, "Unos novog tipa hrane");
            meniTipHrane.DodajOpciju(Brisanje, "Brisanje tipa hrane");
            meniTipHrane.Pokreni();
        }
        public static void Ispis()
        {
            foreach (TipHrane th in Kolekcije.listaTipova)
            {
                Console.WriteLine(th);
            }
        }
        public static void Unos()
        {
            Console.WriteLine($"Upisivanje novog tipa hrane pod sifrom: {TipHrane.brojacId} . . .\n");
            Console.WriteLine("Unesite naziv tipa hrane:");
            string noviNaziv = Console.ReadLine();
            Kolekcije.listaTipova.Add(new TipHrane(noviNaziv));
            Bojadisanje.UspesnaBoja($"Tip hrane '{noviNaziv}' uspesno dodat.");
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
            Console.WriteLine("Unesite ID tipa hrane kojeg zelite obrisati:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            foreach (TipHrane th in Kolekcije.listaTipova)
            {
                if (th.Id == idZaBrisanje)
                {
                    // TODO: ako nijedna hrana ne koristi tip hrane, moze se obrisati
                    // ako neka hrana koristi dati tip hrane, izlazi upozorenje da ce se i te vrste hrane modifikovati/izbrisati
                    // u tom slucaju bi se mogao pokrenuti metod dodele/izmene tipa hrane pre brisanja tipa
                    // Do implementacije navedenih stavki, naredna linija koda ce ostati zakomentarisana.
                    //Kolekcije.listaTipova.Remove(th);
                    Bojadisanje.GresnaBoja($"Tip hrane sa ID brojem {idZaBrisanje} je uspesno obrisan.");
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
                    foreach (TipHrane th in Kolekcije.listaTipova)
                    {
                        sw.WriteLine(th.ToFileString());
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
                        int idTipa = int.Parse(tokeni[0]);
                        string naziv = tokeni[1];
                        Kolekcije.listaTipova.Add(new TipHrane(naziv, idTipa));
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
