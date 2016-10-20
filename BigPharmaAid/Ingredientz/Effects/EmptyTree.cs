using System.Collections.Generic;

namespace BigPharmaAid.Ingredientz.Effects
{
    public class EmptyEffectTree : EffectTree
    {
        public static readonly EmptyEffectTree Empty = new EmptyEffectTree();

        readonly List<Effect> _effects = new List<Effect> {new EmptyEffect()};

        private EmptyEffectTree()
        {
        }

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