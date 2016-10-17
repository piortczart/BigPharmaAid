using System.Collections.Generic;

namespace BigPharmaAid.Ingredientz.Effects
{
    abstract class EffectTree
    {
        public int Slot { get; private set; }

        public abstract List<Effect> GetEffects();

        public void SetSlot(int slot)
        {
            Slot = slot;
            foreach (Effect effect in GetEffects())
            {
                effect.SetSlot(slot);
            }
        }
    }
}