namespace RestoranDomaci
{
    internal class Hrana : Artikl
    {
        public TipHrane TipHrane { get; set; }
        public Hrana(string naziv, TipHrane tipHrane,  double cena, int id=-1)
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
            Cena = cena;
            TipHrane = tipHrane;
        }
        public override string ToFileString()
        {
            return $"{Id},{Naziv},{Cena},{TipHrane.Id}";
        }
        public override string ToString()
        {
            return $"Hrana: {base.ToString()}, tip hrane: {TipHrane}";
        }
    }
}
