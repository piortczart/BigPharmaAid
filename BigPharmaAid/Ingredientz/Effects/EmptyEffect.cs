namespace BigPharmaAid.Ingredientz.Effects
{
    class EmptyEffect : Effect
    {
        public EmptyEffect() : base(0)
        {
            Type = BigPharmaAid.EffectTypes.Empty;
        }

        public override string ToString()
        {
            return "No effect";
        }
    }
}