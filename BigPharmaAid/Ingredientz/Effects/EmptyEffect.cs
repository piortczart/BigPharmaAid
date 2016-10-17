namespace BigPharmaAid.Ingredientz.Effects
{
    class EmptyEffect : Effect
    {
        public EmptyEffect() : base(0)
        {
            Name = "Empty";
        }

        public override string ToString()
        {
            return "No effect";
        }
    }
}