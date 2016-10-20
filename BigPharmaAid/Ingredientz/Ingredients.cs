using System.Collections.Generic;
using System.Linq;

namespace BigPharmaAid.Ingredientz
{
    class Ingredients
    {
        public List<Ingredient> IngredientsBla { get; }

        public Ingredients(IEnumerable<Ingredient> initial)
        {
            IngredientsBla = new List<Ingredient>(initial);
        }

        private void AddNonExisting(IEnumerable<Ingredient> stuff)
        {
            foreach (Ingredient ingredientWithPotential in stuff)
            {
                AddNonExisting(ingredientWithPotential);
            }
        }

        public void Slim()
        {
            List<Ingredient> dupa = IngredientsBla.ToList();

            for (int i = 0; i < dupa.Count; i++)
            {
                for (int j = i + 1; i < dupa.Count; i++)
                {
                    var ingredient = dupa[i];
                    var x = dupa[j];

                    if (ReferenceEquals(ingredient, x))
                    {
                        continue;
                    }

                    if (ingredient.Equals(x))
                    {
                        IngredientsBla.Remove(x);
                    }
                }
            }
        }

        private void AddNonExisting(Ingredient suspect)
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

        public List<Ingredient> GetMostLucrative(int count = 10000)
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