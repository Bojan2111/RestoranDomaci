using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestoranDomaci
{
    internal class StoUI
    {
        public static void MeniStolovi()
        {
            Meni meniSto = new Meni();
            meniSto.DodajOpciju(Ispis, "Ispis svih stolova");
            meniSto.DodajOpciju(Unos, "Unos novog stola");
            meniSto.DodajOpciju(UnosNovogArtikla, "Dodavanje artikla na sto");
            meniSto.DodajOpciju(Brisanje, "Brisanje stola");
            meniSto.Pokreni();
        }
        public static void Ispis()
        {
            foreach (Sto s in Kolekcije.listaStolova)
            {
                Console.WriteLine(s);
            }
        }
        public static void Unos()
        {
            Console.WriteLine($"Kreiranje novog stola pod ID brojem: {Sto.brojacId}");
            Console.WriteLine("Unesite maksimalan broj osoba za ovaj sto:");
            int unos = int.Parse(Console.ReadLine());
            Kolekcije.listaStolova.Add(new Sto(unos));
            Bojadisanje.UspesnaBoja("Uspesno kreiran sto!");
        }
        public static void UnosNovogArtikla()
        {
            Console.WriteLine("Unesite ID stola za koji zelite dodati artikl: ");
            int idStola = int.Parse(Console.ReadLine());
            Console.WriteLine($"Unesite ID artikla koji zelite dodati na sto sa ID {idStola}: ");
            int idArtikla = int.Parse(Console.ReadLine());
            Artikl tempArt = null;
            foreach (Artikl a in Kolekcije.listaArtikala)
            {
                if (a.Id == idArtikla)
                {
                    tempArt = a;
                    break;
                }
            }
            foreach (Sto s in Kolekcije.listaStolova)
            {
                if (s.Id == idStola)
                {
                    s.Artikli.Add(tempArt);
                    break;
                }
            }
            Bojadisanje.UspesnaBoja($"Artikl {tempArt.Naziv} uspesno dodat na sto sa ID {idStola}.");
        }
        public static void Brisanje()
        {
            // posto se artikli vezani za jedan sto memorisu u objektu Sto, brisanjem stola se brisu i njegovi artikli
            Console.WriteLine("Unesite ID stola koji zelite da obrisete:");
            int unos = int.Parse(Console.ReadLine());
            foreach (Sto s in Kolekcije.listaStolova)
            {
                if (unos == s.Id)
                {
                    Kolekcije.listaStolova.Remove(s);
                    Bojadisanje.GresnaBoja("Sto je uspesno obrisan.");
                    break;
                }
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
                        Kolekcije.listaStolova.Add(new Sto(int.Parse(tokeni[1]), int.Parse(tokeni[0])));
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void UcitavanjeArtikalaPoStolu(string adresa)
        {
            if (File.Exists(adresa))
            {
                Dictionary<int, List<Artikl>> tempArt = new Dictionary<int, List<Artikl>>();
                using (StreamReader srArt = new StreamReader(adresa))
                {
                    string linijaArt;
                    while ((linijaArt = srArt.ReadLine()) != null)
                    {
                        string[] tokeni = linijaArt.Split(',');
                        int tempStoId = int.Parse(tokeni[0]);
                        List<Artikl> tempList = new List<Artikl>();
                        for (int i = 1; i < tokeni.Length; i++)
                        {
                            foreach (Artikl a in Kolekcije.listaArtikala)
                            {
                                if (a.Id == int.Parse(tokeni[i]))
                                {
                                    tempList.Add(a);
                                }
                            }
                        }
                        foreach (Sto s in Kolekcije.listaStolova)
                        {
                            if (s.Id == tempStoId)
                            {
                                s.Artikli = tempList;
                                break;
                            }
                        }
                        
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void SacuvajUFajl(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter sw = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (Sto s in Kolekcije.listaStolova)
                    {
                        sw.WriteLine(s.StoloviToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void SacuvajArtiklePoStoluUFajl(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter sw = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (Sto s in Kolekcije.listaStolova)
                    {
                        if (s.Artikli.Count > 0)
                            sw.WriteLine(s.ArtikliPoStoluToFileString());
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
