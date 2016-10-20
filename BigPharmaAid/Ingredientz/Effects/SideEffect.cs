namespace BigPharmaAid.Ingredientz.Effects
{
    public class SideEffect : Effect
    {
        public EffectRemoval EffectRemoval { get; set; }
        public Catalyst Catalyst { get; }

        public SideEffect(Catalyst catalyst = Catalyst.None) : base(0)
        {
            Catalyst = catalyst;
            EffectRemoval = EffectRemoval.Impossible;
        }

        public override string ToString()
        {
            return $"Effect: -{Type}";
        }
    }
}