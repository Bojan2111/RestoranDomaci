using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal class Hrana : Artikl
    {
        public TipHrane TipHrane { get; set; }
        public Hrana(TipHrane tipHrane)
        {
            TipHrane = tipHrane;
        }
        public string ToFileString()
        {
            return $"{Id},{Naziv},{Cena},{TipHrane.Id}";
        }
        public override string ToString()
        {
            return $"{base.ToString()}, tip hrane: {TipHrane}";
        }
    }
}
