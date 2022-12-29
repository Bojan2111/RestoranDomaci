using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class Artikl
    {
        public static int brojacId = 0;
        public int Id { get; set; }
        public string Naziv { get; set; }
        public double Cena { get; set; }

        public Artikl()
        {
            ;
        }

        public Artikl(string naziv, double cena)
        {
            Id = brojacId++;
            Naziv = naziv;
            Cena = cena;
        }

        public Artikl(string naziv, double cena, int id=-1)
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
            Naziv = naziv;
            Cena = cena;
        }

        public override string ToString()
        {
            return $"Sifra: {Id}, Naziv: {Naziv}, Cena: {Cena}";
        }

        public string ToFileString()
        {
            return $"{Naziv},{Cena},{Id}";
        }

    }
}
