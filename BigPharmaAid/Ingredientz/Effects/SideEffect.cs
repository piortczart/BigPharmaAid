namespace BigPharmaAid.Ingredientz.Effects
{
    class SideEffect : Effect
    {
        public bool IsRemovable { get; set; }
        public Catalyst Catalyst { get; set; }

        public SideEffect() : base(0)
        {
        }

        public override string ToString()
        {
            return $"Effect: -{Name}";
        }
    }
}