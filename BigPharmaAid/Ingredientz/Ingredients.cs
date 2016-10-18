using System.Collections.Generic;
using System.Linq;

namespace BigPharmaAid.Ingredientz
{
    class Ingredients
    {
        public List<IngredientWithPotential> IngredientsBla { get; }

        public Ingredients(IEnumerable<IngredientWithPotential> initial)
        {
            IngredientsBla = new List<IngredientWithPotential>(initial);
        }

        private void AddNonExisting(IEnumerable<IngredientWithPotential> stuff)
        {
            foreach (IngredientWithPotential ingredientWithPotential in stuff)
            {
                AddNonExisting(ingredientWithPotential);
            }
        }

        private void AddNonExisting(IngredientWithPotential suspect)
        {
            //if (!IngredientsBla.Any(ex =>
            //    ex.Level == suspect.Level &&
            //    ex.EffectTreesPossible[0] == suspect.EffectTreesPossible[0] &&
            //    ex.EffectTreesPossible[1] == suspect.EffectTreesPossible[1] &&
            //    ex.EffectTreesPossible[2] == suspect.EffectTreesPossible[2] &&
            //    ex.EffectTreesPossible[3] == suspect.EffectTreesPossible[3] &&
            //    ex.Profit == suspect.Profit
            //    ))
            //{
            //    IngredientsBla.Add(suspect);
            //}
            IngredientsBla.Add(suspect);
        }

        public List<IngredientWithPotential> GetMostLucrative(int count = 10000)
        {
            return IngredientsBla.OrderByDescending(i => i.Balance).Take(count).ToList();
        }

        public void AddPossibleTransformations()
        {
            foreach (var ing in IngredientsBla.ToList())
            {
                AddNonExisting(ing.GetPossibleTransformations(false));
            }
        }

        public void AddMixed()
        {
            var initialList = IngredientsBla.ToList();
            foreach (var ing1 in initialList)
            {
                foreach (var ing2 in initialList)
                {
                    if (ing1 != ing2)
                        AddNonExisting(ing1.Mix(ing2));
                }
            }
        }

        public void AddWithNoSideEffects()
        {
            AddNonExisting(IngredientsBla.SelectMany(i => i.GetWithoutSideEffects(false)));
        }
    }
}