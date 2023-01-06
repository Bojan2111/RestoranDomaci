using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class RacunUI
    {
        public static void MeniRacun()
        {
            Meni meniRacun = new Meni();
            meniRacun.DodajOpciju(Ispis, "Ispis svih racuna");
            meniRacun.DodajOpciju(IspisRacuna, "Ispis odredjenog racuna");
            meniRacun.DodajOpciju(StoUI.IzdavanjeRacuna, "Izdavanje racuna za odredjeni sto");
            meniRacun.DodajOpciju(Brisanje, "Brisanje racuna");

            meniRacun.Pokreni();
        }
        public static void Ispis()
        {
            foreach (Racun r in Kolekcije.listaRacuna)
            {
                Console.WriteLine(r);
            }
        }
        public static void IspisRacuna()
        {
            Console.WriteLine("Unesite broj racuna za ispis:");
            int idRacuna = int.Parse(Console.ReadLine());
            foreach (Racun r in Kolekcije.listaRacuna)
            {
                if (idRacuna == r.Id)
                    Console.WriteLine(r);
            }
        }

        public static void Brisanje()
        {
            Console.WriteLine("Unesite ID broj racuna za brisanje:");
            int idZaBrisanje = int.Parse(Console.ReadLine());
            
            foreach (Racun r in Kolekcije.listaRacuna)
            {
                if (idZaBrisanje == r.Id)
                {
                    foreach (StavkaRacuna sr in r.Stavke)
                    {
                        foreach (StavkaRacuna sri in Kolekcije.listaStavki)
                        {
                            if (sr.Id == sri.Id)
                            {
                                Kolekcije.listaStavki.Remove(sri);
                                break;
                            }
                        }
                    }
                    Kolekcije.listaRacuna.Remove(r);
                    Bojadisanje.GresnaBoja("Racun uspesno obrisan.");
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
                    foreach (Racun r in Kolekcije.listaRacuna)
                    {
                        sw.WriteLine(r.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void SacuvajStavkeUFajl(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamWriter sw = new StreamWriter(adresa, false, Encoding.UTF8))
                {
                    foreach (StavkaRacuna sr in Kolekcije.listaStavki)
                    {
                        sw.WriteLine(sr.ToFileString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Fajl ne postoji ili je nepravilna putanja" + adresa);
            }
        }
        public static void UcitavanjeStavki(string adresa)
        {
            if (File.Exists(adresa))
            {
                using (StreamReader sr = new StreamReader(adresa))
                {
                    string linija;
                    while((linija = sr.ReadLine()) != null)
                    {
                        string[] tokeni = linija.Split(',');
                        int idStavke = int.Parse(tokeni[0]);
                        int idArtikla = int.Parse(tokeni[1]);
                        int kolicina = int.Parse(tokeni[2]);
                        Artikl tempArtikl = null;
                        foreach (Artikl a in Kolekcije.listaArtikala)
                        {
                            if (idArtikla == a.Id)
                            {
                                tempArtikl = a;
                            }
                        }
                        Kolekcije.listaStavki.Add(new StavkaRacuna(tempArtikl, kolicina, idStavke));
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
                        int idRacuna = int.Parse(tokeni[0]);
                        int idStola = int.Parse(tokeni[1]);
                        Sto tempSto = null;
                        List<StavkaRacuna> tempStavke = new List<StavkaRacuna>();
                        if (tokeni.Length < 3)
                        {
                            Bojadisanje.GresnaBoja("Racun ne moze biti kreiran iz fajla. Nedostaju artikli!");
                            Environment.Exit(0);
                        }
                        else
                        {
                            foreach (Sto s in Kolekcije.listaStolova)
                            {
                                if (s.Id == idStola)
                                {
                                    tempSto = s;
                                    break;
                                }
                            }
                            for (int i = 2; i < tokeni.Length; i++)
                            {
                                foreach (StavkaRacuna str in Kolekcije.listaStavki)
                                {
                                    if (str.Id == int.Parse(tokeni[i]))
                                    {
                                        tempStavke.Add(str);
                                        break;
                                    }
                                }
                            }
                            Kolekcije.listaRacuna.Add(new Racun(tempSto, tempStavke, idRacuna));
                        }
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
