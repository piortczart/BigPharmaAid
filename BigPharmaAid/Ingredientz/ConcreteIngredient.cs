using System;
using System.Collections.Generic;
using System.Linq;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid.Ingredientz
{
    class ConcreteIngredient : IEquatable<ConcreteIngredient>
    {
        public IngredientWithPotential DerivedFrom { get; }

        public Effect[] Effects { get; }

        public List<Catalyst> CatalystsRequired
        {
            get
            {
                return
                    PositiveEffects
                        .Where(p => p.CatalystRequired != Catalyst.None)
                        .Select(p => p.CatalystRequired)
                        .ToList();
            }
        }

        public IEnumerable<PositiveEffect> PositiveEffects
        {
            get { return Effects.Where(e => e is PositiveEffect).Cast<PositiveEffect>(); }
        }

        public Tuple<int, int> MaxProfit
        {
            get
            {
                int max = -1;
                int level = -1;
                for (int i = 0; i < 19; i++)
                {
                    int localMax = GetProfitAtActivityLevel(i);
                    if (max < localMax)
                    {
                        max = localMax;
                        level = i;
                    }
                }

                return new Tuple<int, int>(max, level);
            }
        }

        public int GetProfitAtActivityLevel(int level)
        {
            return PositiveEffects.Where(e => e.ActiveRange.Contains(level)).Sum(e => e.Profit);
        }

        public ConcreteIngredient(IngredientWithPotential derivedFrom, Effect[] effects)
        {
            Effects = effects;
            DerivedFrom = derivedFrom;
        }

        public bool Equals(ConcreteIngredient other)
        {
            if (other == null)
            {
                return false;
            }

            if (this.DerivedFrom.Name == other.DerivedFrom.Name)
            {
                ;
            }

            for (int i = 0; i < Effects.Length; i++)
            {
                if (Effects[i] != other.Effects[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Effects[0].GetHashCode() ^ Effects[1].GetHashCode() ^ Effects[2].GetHashCode() ^
                   Effects[3].GetHashCode();
        }

        public override string ToString()
        {
            return $"Ingredient: {DerivedFrom.Name}";
        }

        public bool HasRequiredCatalysts()
        {
            foreach (Catalyst required in CatalystsRequired)
            {
                bool hasCatalyst =
                    Effects.Where(e => e is SideEffect).Cast<SideEffect>().Any(se => se.Catalyst == required);
                if (!hasCatalyst)
                {
                    return false;
                }
            }
            return true;
        }

        public ConcreteIngredient Clone()
        {
            var result = new ConcreteIngredient(DerivedFrom, new Effect[Effects.Length]);
            Effects.CopyTo(result.Effects, 0);
            return result;
        }
    }
}