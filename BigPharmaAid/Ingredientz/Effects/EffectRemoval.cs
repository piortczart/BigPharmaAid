namespace BigPharmaAid.Ingredientz.Effects
{
    public class EffectRemoval
    {
        public static readonly EffectRemoval Impossible = new EffectRemoval(new IntRange(-1, -1));

        public IntRange RemovalRange { get; }

        public EffectRemoval(IntRange removalRange)
        {
            RemovalRange = removalRange;
        }
    }
}