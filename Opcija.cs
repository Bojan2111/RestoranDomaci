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
