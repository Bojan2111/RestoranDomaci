using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace RestoranDomaci
{
    internal class Program
    {
        private static readonly string dataDir = "data";
        private static readonly string artiklData = "artikl.csv";
        private static readonly string stoData = "stolovi.csv";
        private static readonly string artStoDat = "artikliPoStolu.csv";
        private static readonly char sep = Path.DirectorySeparatorChar;
        private static string PodesiPutanju()
        {
            DirectoryInfo dir = new DirectoryInfo($".{sep}..{sep}..{sep}..{sep}{dataDir}{sep}");
            return dir.FullName;
        }

        static void Main()
        {
            string putanja = PodesiPutanju();
            // Ucitavanje podataka iz fajlova na pocetku programa
            ArtiklUI.Ucitavanje(putanja + artiklData);
            StoUI.Ucitavanje(putanja + stoData);
            StoUI.UcitavanjeArtikalaPoStolu(putanja + artStoDat);

            // Ispis menija
            Meni glavniMeni = new Meni();
            glavniMeni.DodajOpciju(ArtiklUI.Ispis, "Ispisi sve artikle");
            glavniMeni.DodajOpciju(ArtiklUI.Unos, "Unos novog artikla");
            glavniMeni.DodajOpciju(ArtiklUI.Brisanje, "Brisanje artikla");
            glavniMeni.DodajOpciju(StoUI.Ispis, "Ispis svih stolova");
            glavniMeni.DodajOpciju(StoUI.Unos, "Unos novog stola");
            glavniMeni.DodajOpciju(StoUI.UnosNovogArtikla, "Dodavanje artikla na sto");
            glavniMeni.DodajOpciju(StoUI.Brisanje, "Brisanje stola");
            glavniMeni.Pokreni();

            // Cuvanje podataka u fajlove na kraju programa
            ArtiklUI.SacuvajUFajl(putanja + artiklData);
            StoUI.SacuvajUFajl(putanja + stoData);
            StoUI.SacuvajArtiklePoStoluUFajl(putanja + artStoDat);

        }
    }
}
