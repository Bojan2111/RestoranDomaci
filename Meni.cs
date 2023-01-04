using System;
using System.Collections.Generic;

namespace RestoranDomaci
{
    class Meni
    {
        public List<Opcija> listaOpcija;

        public Meni()
        {
            listaOpcija = new List<Opcija>();
        }


        public void DodajOpciju(FunkcijaOpcije funkcija, string tekst)
        {
            listaOpcija.Add(new Opcija(funkcija, tekst));
        }

        private void IspisiMeni()
        {

            Console.WriteLine("Opcije:");

            int redniBrojOpcije = 1;
            foreach (Opcija o in listaOpcija)
            {
                Console.WriteLine($"{redniBrojOpcije} - {o.Tekst}");
                redniBrojOpcije++;
            }

            Console.WriteLine("\n0 - Nazad\n" +
                "---------------------------------");
        }

        public int PreuzmiOpcijuOdKorisnika()
        {
            Console.Write($"Unesite opciju (0-{listaOpcija.Count}): ");

            string unos = Console.ReadLine();
            Console.WriteLine();

            int odabranaOpcija;

            bool daLiJeBroj = int.TryParse(unos, out odabranaOpcija);
            if (daLiJeBroj == false)
            {
                Bojadisanje.GresnaBoja("Neispravan unos!");
                return -1;
            }

            if (odabranaOpcija < 0 || odabranaOpcija > listaOpcija.Count)
            {
                Bojadisanje.GresnaBoja($"Unesite broj opcije od 0 do {listaOpcija.Count}");
                return -1;
            }

            return odabranaOpcija;
        }

        public void IzvrsiOpciju(int brojOpcije)
        {
            if (brojOpcije > 0 && brojOpcije <= listaOpcija.Count)
            {
                listaOpcija[brojOpcije - 1].Funkcija();
            }
            Console.WriteLine();
        }

        public void Pokreni()
        {
            int odabranaOpcija;
            do
            {
                IspisiMeni();
                odabranaOpcija = PreuzmiOpcijuOdKorisnika();
                IzvrsiOpciju(odabranaOpcija);
            } while (odabranaOpcija != 0);
        }
    }
}
