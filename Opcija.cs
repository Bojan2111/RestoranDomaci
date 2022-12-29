using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    public delegate void FunkcijaOpcije();

    class Opcija
    {
        public string Tekst { set; get; }
        public FunkcijaOpcije Funkcija { set; get; }

        public Opcija(FunkcijaOpcije funkcija, string tekst)
        {
            Funkcija = funkcija;
            Tekst = tekst;
        }
    }
}
