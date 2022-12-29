using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci.Interfejsi
{
    internal interface IReadWriteDeletable
    {
        public static void Ucitavanje() { }
        public static void SacuvajUFajl() { }
        public static void Ispis() { }
        public static void Unos() { }
        public static void Brisanje() { }
    }
}
