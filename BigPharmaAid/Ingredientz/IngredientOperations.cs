using System;
using System.Collections.Generic;
using System.Linq;

namespace BigPharmaAid.Ingredientz
{
    class IngredientOperations
    {
        public List<IngredientOperation> Operations { get; }

        public int Cost => Operations.Sum(o => o.Cost);

        public IngredientOperations(IngredientOperations initial = null, IngredientOperation extra = null)
            : this(initial)
        {
            if (extra != null)
            {
                Add(extra);
            }
        }

        public IngredientOperations(IngredientOperations initial = null)
        {
            Operations = new List<IngredientOperation>(initial?.Operations ?? new List<IngredientOperation>());
        }

        public override string ToString()
        {
            return String.Join(",", Operations);
        }

        public void Add(IngredientOperation ingredientOperation)
        {
            Operations.Add(ingredientOperation);
        }
    }
}