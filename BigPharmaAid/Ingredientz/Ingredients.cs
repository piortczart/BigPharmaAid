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

        public void AddPossibleTransformations()
        {
            foreach (var ing in IngredientsBla.ToList())
            {
                IngredientsBla.AddRange(ing.GetPossibleTransformations(false));
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
                        IngredientsBla.Add(ing1.Mix(ing2));
                }
            }
        }

        public void AddWithNoSideEffects()
        {
            IngredientsBla.AddRange(IngredientsBla.SelectMany(i => i.GetWithoutSideEffects(false)).ToList());
        }
    }
}