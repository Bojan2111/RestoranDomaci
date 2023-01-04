namespace RestoranDomaci
{
    internal class TipHrane
    {
        public static int brojacId = 0;
        public int Id { get; set; }
        public string Tip { get; set; }
        public TipHrane(string tip, int id=-1)
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
            Tip = tip;
        }
        public string ToFileString()
        {
            return $"{Id},{Tip}";
        }
        public override string ToString()
        {
            return Tip;
        }
    }
}
