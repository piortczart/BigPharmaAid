using System;
using System.Collections.Generic;
using System.Linq;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid.Ingredientz
{
    class IngredientOperation
    {
        public List<IngredientWithPotential> Ingredients { get; private set; }
        public OperationType OperationType { get; private set; }
        public int Cost { get; private set; }
        public List<int> LevelChanges { get; private set; }
        public int EffectsRemovedCount { get; set; }
        public Machine Machine { get; private set; }

        public static IngredientOperation GetSideEffectRemoval(List<int> levelChanges, int effectsRemovedCount)
        {
            int cost =
                // Sum costs of all level changes.
                levelChanges.Sum(lc => Math.Abs(Constants.LevelChangeCost*lc)) +
                // And add the cost of the removals themselves.
                effectsRemovedCount*Constants.SideEffectRemovalCost;

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
                Cost = Constants.MixCost
            };
        }

        public static IngredientOperation GetLevelChange(int levelChange, Machine machine = null)
        {
            return new IngredientOperation
            {
                OperationType = OperationType.ChangeLevel,
                LevelChanges = new List<int> {levelChange},
                Cost = Math.Abs(levelChange)*Constants.LevelChangeCost,
                Machine = machine
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
                    return $"Mix with {Ingredients[1]} {Machine}";
                case OperationType.RemoveSideEffects:
                    return $"Remove Side Effects ({EffectsRemovedCount}) {Machine}";
                case OperationType.ChangeLevel:
                    return $"Change level (change: {LevelChanges[0]}) {Machine}";
                default:
                    throw new IndexOutOfRangeException();
            }
        }
    }
}