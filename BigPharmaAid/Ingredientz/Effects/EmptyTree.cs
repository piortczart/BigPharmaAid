using System.Collections.Generic;

namespace BigPharmaAid.Ingredientz.Effects
{
    class EmptyTree : EffectTree
    {
        readonly List<Effect> _effects = new List<Effect> {new EmptyEffect()};

        public override List<Effect> GetEffects()
        {
            return _effects;
        }

        public override string ToString()
        {
            return "Empty tree.";
        }
    }
}