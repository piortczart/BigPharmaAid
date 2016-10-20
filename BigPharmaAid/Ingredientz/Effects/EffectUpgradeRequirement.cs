namespace BigPharmaAid.Ingredientz.Effects
{
    public class EffectUpgradeRequirement
    {
        public static readonly EffectUpgradeRequirement Unknown = null;
        public IntRange Concentration { get; }
        public Machine Machine { get; }
        public Catalyst Catalyst { get; }

        public EffectUpgradeRequirement(IntRange concentration, Machine machine,
            Catalyst catalyst = Catalyst.None)
        {
            Concentration = concentration;
            Machine = machine;
            Catalyst = catalyst;
        }
    }
}