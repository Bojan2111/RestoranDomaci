using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace RestoranDomaci
{
    internal class Program
    {
        private static readonly string dataDir = "data";
        //private static readonly string artiklData = "artikl.csv";
        private static readonly string piceData = "pice.csv";
        private static readonly string tipHraneDat = "tipHrane.csv";
        private static readonly string hranaData = "hrana.csv";
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
            //ArtiklUI.Ucitavanje(putanja + artiklData);
            TipoviUI.Ucitavanje(putanja + tipHraneDat);
            PiceUI.Ucitavanje(putanja + piceData);
            HranaUI.Ucitavanje(putanja + hranaData);
            StoUI.Ucitavanje(putanja + stoData);
            StoUI.UcitavanjeArtikalaPoStolu(putanja + artStoDat);

            // Ispis menija
            Meni glavniMeni = new Meni();
            glavniMeni.DodajOpciju(ArtiklUI.MeniArtikli, "Artikli");
            glavniMeni.DodajOpciju(StoUI.MeniStolovi, "Stolovi");
            glavniMeni.Pokreni();

            // Cuvanje podataka u fajlove na kraju programa
            //ArtiklUI.SacuvajUFajl(putanja + artiklData);
            TipoviUI.SacuvajUFajl(putanja + tipHraneDat);
            PiceUI.SacuvajUFajl(putanja + piceData);
            HranaUI.SacuvajUFajl(putanja + hranaData);
            StoUI.SacuvajUFajl(putanja + stoData);
            StoUI.SacuvajArtiklePoStoluUFajl(putanja + artStoDat);

        }
    }
}
