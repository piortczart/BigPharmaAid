namespace BigPharmaAid.Ingredientz.Effects
{
    class PositiveEffect : Effect
    {
        public EffectUpgradeRequirement Requirement { get; }
        public int Profit { get; set; }

        public PositiveEffect(int level, EffectUpgradeRequirement requirement) : base(level)
        {
            Requirement = requirement;
        }

        public override string ToString()
        {
            return $"+{Type} ({Level})";
        }
    }
}