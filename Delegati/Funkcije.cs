using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci.Delegati
{
    public delegate void TestDelegat();
    class Funkcije
    {
        public TestDelegat Funkcija { get; set; }
        public Funkcije(TestDelegat funkcija)
        {
            Funkcija = funkcija;
        }
    }
}
