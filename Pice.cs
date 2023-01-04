using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class Pice : Artikl
    {
        public double Zapremina { get; set; }
        public Pice(string naziv, double zapremina, double cena, int id=-1)
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
            Naziv = naziv;
            Zapremina = zapremina;
            Cena = cena;
        }
        public override string ToFileString()
        {
            return $"{Naziv},{Zapremina},{Cena},{Id}";
        }

        public override string ToString()
        {
            return $"Pice: {base.ToString()}, zapremina: {Zapremina}l";
        }
    }
}
