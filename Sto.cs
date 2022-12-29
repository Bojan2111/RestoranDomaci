using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class Sto
    {
        public static int brojacId = 0;
        public int Id { get; set; }
        public int MaxOsoba { get; set; }
        public List<Artikl> Artikli { get; set; }
        public Sto()
        {
            Artikli = new List<Artikl>();
        }
        public Sto(int maxOsoba)
        {
            Id = brojacId++;
            MaxOsoba = maxOsoba;
            Artikli = new List<Artikl>();
        }
        public Sto(int maxOsoba, int id = -1)
        {
            if (id == -1)
            {
                this.Id = brojacId++;
            }
            else if (id >= brojacId)
            {
                this.Id = id;
                brojacId = ++id;
            }
            MaxOsoba = maxOsoba;
            Artikli = new List<Artikl>();
        }
        public Sto(int maxOsoba, List<Artikl> artikli, int id=-1)
        {
            if (id == -1)
            {
                this.Id = brojacId++;
            }
            else if (id >= brojacId)
            {
                this.Id = id;
                brojacId = ++id;
            }
            MaxOsoba = maxOsoba;
            Artikli = artikli;
        }
        public string StoloviToFileString()
        {
            return $"{Id},{MaxOsoba}";
        }
        public string ArtikliPoStoluToFileString()
        {
            if ( Artikli.Count > 0)
            {
                StringBuilder sbArtIds = new StringBuilder();
                sbArtIds.Append(Artikli[0].Id);
                for (int i = 1; i<Artikli.Count; i++)
                {
                    sbArtIds.Append(',');
                    sbArtIds.Append(Artikli[i].Id);
                }
                // ID stola,ID-evi artikala za dati sto. Posebno se skladisti u medju-listi/datoteci.
                return $"{Id},{sbArtIds}";
            }
            return "";
            
        }

        public override string ToString()
        {
            if (Artikli.Equals(null) || Artikli.Count == 0)
            {
                return $"ID stola: {Id}, Maksimalan broj osoba: {MaxOsoba}, Artikli za ovaj sto nisu odabrani";
            }
            StringBuilder sbArtikli = new StringBuilder();
            Artikl poslednjiUListi = Artikli.Last();
            foreach (Artikl a in Artikli)
            {
                sbArtikli.Append(a.Naziv);
                sbArtikli.Append(", ");

            }
            //sbArtikli.Append("Test");
            return $"ID stola: {Id}, Maksimalan broj osoba: {MaxOsoba}, Artikli: {sbArtikli}";
        }
    }
}
