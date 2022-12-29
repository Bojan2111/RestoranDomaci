using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestoranDomaci
{
    internal static class Bojadisanje
    {
        public static void GresnaBoja(string poruka)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(poruka);
            Console.ResetColor();
        }
        public static void UspesnaBoja(string poruka)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(poruka);
            Console.ResetColor();
        }
    }
}
