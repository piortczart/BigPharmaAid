using System.Collections.Generic;
using System.Linq;

namespace BigPharmaAid.Ingredientz.Effects
{
    class PositiveEffectTree : EffectTree
    {
        public List<PositiveEffect> Effects { get; set; }

        public override List<Effect> GetEffects()
        {
            return Effects.Cast<Effect>().ToList();
        }

        public override string ToString()
        {
            return $"PositiveTree: {Effects[0].Name}, (...)";
        }
    }
}