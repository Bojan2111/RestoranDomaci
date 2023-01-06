using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class Racun
    {
        public static int brojacID = 1;
        public int Id { get; set; }
        public Sto ZaSto { get; set; }
        public List<StavkaRacuna> Stavke { get; set; }
        public Racun(Sto zaSto, List<StavkaRacuna> stavke, int id = -1)
        {
            if (id == -1)
            {
                Id = brojacID++;
            }
            else if (id >= brojacID)
            {
                Id = id;
                brojacID = ++id;
            }
            ZaSto = zaSto;
            Stavke = stavke;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (StavkaRacuna s in Stavke)
            {
                sb.Append(s);
            }
            return $"\n{new string('=', 30)}\n" +
                $"Racun Br. {Id} za sto Br. {ZaSto.Id}:\n" +
                $"{sb}\n{new string('=', 30)}\n" +
                $"UKUPNO:{new string(' ', 16)}{IzracunajStavke(Stavke):0.00}";
        }
        public double IzracunajStavke(List<StavkaRacuna> stavkeLista)
        {
            double ukupnaCena = 0;
            foreach (StavkaRacuna s in Stavke)
            {
                ukupnaCena += s.ArtiklStavke.Cena * s.Kolicina;
            }
            return ukupnaCena;
        }
        public string ToFileString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (StavkaRacuna s in Stavke)
            {
                sb.Append($",{s.Id}");
            }
            return $"{Id},{ZaSto.Id}{sb}";
        }
    }
}
