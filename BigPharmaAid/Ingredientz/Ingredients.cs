using System.Collections.Generic;
using System.Linq;

namespace BigPharmaAid.Ingredientz
{
    class Ingredients
    {
        public List<IngredientWithPotential> IngredientsBla { get; }

        public Ingredients()
        {
            IngredientsBla = new List<IngredientWithPotential>();
        }

        public void AddMixed()
        {
            var resut = new List<IngredientWithPotential>();
            foreach (var ing1 in IngredientsBla)
            {
                foreach (var ing2 in IngredientsBla)
                {
                    if (ing1 != ing2)
                        resut.Add(ing1.Mix(ing2));
                }
            }
            IngredientsBla.AddRange(resut);
        }

        public void AddWithNoSideEffects()
        {
            IngredientsBla.AddRange(IngredientsBla.Select(i => i.GetWithoutSideEffects()).ToList());
        }

        public List<ConcreteIngredient> GetConcreteIngredients()
        {
            return IngredientsBla.
                SelectMany(i => i.GetPossibleConctetes()).
                OrderByDescending(c => c.MaxProfit.Item1).
                ToList();
        }
    }
}