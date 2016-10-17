using System;
using System.Collections.Generic;
using System.Linq;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid.Ingredientz
{
    class IngredientWithPotential
    {
        public List<IngredientOperation> Operations { get; }
        public EffectTree[] EffectTrees { get; }
        public string Name { get; }

        public IngredientWithPotential(string name, EffectTree[] effectTrees)
        {
            if (effectTrees.Length != 4)
            {
                throw new ArgumentException("Needs to have exactly 4 effect trees.", nameof(effectTrees));
            }

            Name = name;
            Operations = new List<IngredientOperation>();
            EffectTrees = effectTrees;
            for (int i = 0; i < effectTrees.Length; i++)
            {
                EffectTrees[i].SetSlot(i);
            }
        }


        private static List<string> GetOperationsUnsafe(IngredientWithPotential ingredient)
        {
            var result = new List<string>();
            foreach (var operation in ingredient.Operations)
            {
                result.Add($"{operation.OperationType}: {String.Join(",", operation.Ingredients)}");

                foreach (var deeperIngredient in operation.Ingredients)
                {
                    result.AddRange(GetOperationsUnsafe(deeperIngredient));
                }
            }
            return result;
        }

        public List<string> GetOperations()
        {
            return GetOperationsUnsafe(this);
        }

        public IEnumerable<EffectTree> GetemptyTrees()
        {
            return EffectTrees.Where(t => t is EmptyTree);
        }

        public IEnumerable<PositiveEffectTree> GetPositivEffectTrees()
        {
            return EffectTrees.Where(t => t is PositiveEffectTree).Cast<PositiveEffectTree>();
        }

        public IEnumerable<SideEffectTree> GetSideEffectTrees()
        {
            return EffectTrees.Where(t => t is SideEffectTree).Cast<SideEffectTree>();
        }

        public IEnumerable<ConcreteIngredient> GetPossibleConctetes()
        {
            var possible0 = EffectTrees[0].GetEffects();
            var possible1 = EffectTrees[1].GetEffects();
            var possible2 = EffectTrees[2].GetEffects();
            var possible3 = EffectTrees[3].GetEffects();

            foreach (var effect0 in possible0)
            {
                foreach (var effect1 in possible1)
                {
                    foreach (var effect2 in possible2)
                    {
                        foreach (var effect3 in possible3)
                        {
                            var local = new ConcreteIngredient(this, new[] {effect0, effect1, effect2, effect3});

                            // No catalyst? Not possible to make it.
                            if (!local.HasRequiredCatalysts())
                            {
                                yield break;
                            }

                            yield return local;
                        }
                    }
                }
            }
        }

        private IngredientWithPotential Clone()
        {
            var treesCopy = new EffectTree[EffectTrees.Length];
            EffectTrees.CopyTo(treesCopy, 0);
            return new IngredientWithPotential(Name, treesCopy);
        }

        public IngredientWithPotential Mix(IngredientWithPotential other)
        {
            // The base has no free slots? Result will be the base.
            if (!EffectTrees.Any(e => e is EmptyTree))
            {
                return this;
            }

            var result = Clone();
            for (int i = 0; i < result.EffectTrees.Length; i++)
            {
                if (result.EffectTrees[i] is EmptyTree)
                {
                    result.EffectTrees[i] = other.EffectTrees[i];
                }
            }
            result.Operations.Add(new IngredientOperation
            {
                Ingredients = new List<IngredientWithPotential> {this, other},
                OperationType = OperationType.Mix
            });
            return result;
        }

        public IngredientWithPotential GetWithoutSideEffects()
        {
            // No removable side effects? Do not clone.
            if (GetSideEffectTrees().All(t => !t.Effect.IsRemovable))
            {
                return this;
            }

            var result = Clone();
            for (int i = 0; i < result.EffectTrees.Length; i++)
            {
                var sideEffectTree = result.EffectTrees[i] as SideEffectTree;
                if (sideEffectTree != null && sideEffectTree.Effect.IsRemovable)
                {
                    result.EffectTrees[i] = new EmptyTree();
                    result.EffectTrees[i].SetSlot(i);
                }
            }
            result.Operations.Add(new IngredientOperation
            {
                Ingredients = new List<IngredientWithPotential> {this},
                OperationType = OperationType.RemoveSideEffects
            });
            return result;
        }

        public override string ToString()
        {
            return $"IWP: {Name}";
        }
    }
}