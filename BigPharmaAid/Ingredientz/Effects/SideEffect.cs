namespace BigPharmaAid.Ingredientz.Effects
{
    class EffectRemoval
    {
        public static readonly EffectRemoval Impossible = new EffectRemoval(new IntRange(-1, -1));

        public IntRange RemovalRange { get; }

        public EffectRemoval(IntRange removalRange)
        {
            RemovalRange = removalRange;
        }
    }

    class SideEffect : Effect
    {
        public EffectRemoval EffectRemoval { get; set; }
        public Catalyst Catalyst { get; }

        public SideEffect(Catalyst catalyst = Catalyst.None) : base(0)
        {
            Catalyst = catalyst;
        }

        public override string ToString()
        {
            return $"Effect: -{Name}";
        }
    }
}