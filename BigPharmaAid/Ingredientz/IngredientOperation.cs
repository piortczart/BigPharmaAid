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

    class IngredientOperation
    {
        const int MixCost = 40;
        const int LevelChangeCost = 10;
        const int SideEffectRemovalCostPerLevel = 30;

        public List<IngredientWithPotential> Ingredients { get; private set; }
        public OperationType OperationType { get; private set; }
        public int Cost { get; private set; }
        public List<int> LevelChanges { get; private set; }
        public int EffectsRemovedCount { get; set; }

        public static IngredientOperation GetSideEffectRemoval(List<int> levelChanges, int effectsRemovedCount)
        {
            int cost =
                // Sum costs of all level changes.
                levelChanges.Sum(c => Math.Abs(c)) * LevelChangeCost +
                // And add the cost of the removals themselves.
                effectsRemovedCount * SideEffectRemovalCostPerLevel;

            return new IngredientOperation
            {
                OperationType = OperationType.RemoveSideEffects,
                LevelChanges = levelChanges,
                EffectsRemovedCount = effectsRemovedCount,
                Cost = cost
            };
        }

        public static IngredientOperation GetMixing(List<IngredientWithPotential> ingredients)
        {
            return new IngredientOperation
            {
                OperationType = OperationType.Mix,
                Ingredients = ingredients,
                Cost = MixCost
            };
        }

        public static IngredientOperation GetLevelChange(int levelChange)
        {
            return new IngredientOperation
            {
                OperationType = OperationType.Mix,
                LevelChanges = new List<int> { levelChange },
                Cost = levelChange * LevelChangeCost
            };
        }

        private IngredientOperation()
        {
        }

        public override string ToString()
        {
            switch (OperationType)
            {
                case OperationType.Mix:
                    return $"Mix with {Ingredients[1]}";
                case OperationType.RemoveSideEffects:
                    return $"Remove Side Effects ({EffectsRemovedCount})";
                case OperationType.ChangeLevel:
                    return $"Change level (change: {LevelChanges[0]})";
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}