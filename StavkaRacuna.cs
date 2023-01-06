using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class StavkaRacuna
    {
        public static int brojacId = 1;
        public int Id { get; set; }
        public Artikl ArtiklStavke { get; set; }
        public int Kolicina { get; set; }

        public StavkaRacuna(Artikl artiklStavke, int kolicina, int id = -1)
        {
            if (id == -1)
            {
                Id = brojacId++;
            }
            else if (id >= brojacId)
            {
                Id = id;
                brojacId = ++id;
            }
            ArtiklStavke = artiklStavke;
            Kolicina = kolicina;
        }

        public string ToFileString()
        {
            return $"{Id},{ArtiklStavke.Id},{Kolicina}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is StavkaRacuna))
                return false;
            StavkaRacuna sr = (StavkaRacuna)obj;
            return this.Id == sr.Id;
        }

        public override string ToString()
        {
            return $"\n{Id}|{ArtiklStavke.Naziv}{new string(' ',13)}{ArtiklStavke.Cena:0.00}\n" +
                $"\t X {Kolicina}{new string(' ', 12)}{ArtiklStavke.Cena * Kolicina:0.00}\n" +
                $"{new string('-', 30)}\n";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
