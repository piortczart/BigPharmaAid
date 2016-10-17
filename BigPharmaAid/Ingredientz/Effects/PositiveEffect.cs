namespace BigPharmaAid.Ingredientz.Effects
{
    class PositiveEffect : Effect
    {
        public int Profit { get; set; }

        public Catalyst CatalystRequired { get; set; }

        public PositiveEffect(int level) : base(level)
        {
        }

        public override string ToString()
        {
            return $"Effect: +{Name}";
        }
    }
}