using System.Collections.Generic;

namespace BigPharmaAid.Ingredientz.Effects
{
    class SideEffectTree : EffectTree
    {
        public SideEffect Effect { get; set; }

        public override List<Effect> GetEffects()
        {
            return new List<Effect> { Effect };
        }

        public override string ToString()
        {
            return $"SideEffectTree: {Effect.Name}";
        }
    }
}