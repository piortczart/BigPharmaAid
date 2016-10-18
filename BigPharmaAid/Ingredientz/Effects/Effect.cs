namespace BigPharmaAid.Ingredientz.Effects
{
    abstract class Effect
    {
        public int Level { get; }
        public IntRange ActiveRange { get; set; }
        public EffectTypes Type { get; set; }
        public int Slot { get; private set; }

        public Effect(int level)
        {
            Level = level;
        }

        public void SetSlot(int slot)
        {
            Slot = slot;
        }
    }
}