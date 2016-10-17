using System;
using System.Collections.Generic;
using System.Linq;
using BigPharmaAid.Ingredientz;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid
{
    class Program
    {
        static void Main(string[] args)
        {
            // Do not work on concteres! Work on potentials!
            // Materialize concretes when needed.
            // Mix potentials. At some point a mixed potential will create a concrete if it needed catalyst.
            // 
            // 1. Make more concrete - remove side effects
            // 2. How to make concrete if Catalyst needed? 
            //      - Have the list of "base" ingrediends and somehow select the one needed?
            //      - Ignore those at the first run of making concretes. 
            //        Do the mixing of everything. Now there is a concrete with mixed in Catalyst?
            //        Make concretes from concretes?

            var ings = Game02.GetIngredients();

            var ingsX = new Ingredients();
            ingsX.IngredientsBla.AddRange(ings);

            var best1 = ingsX.GetConcreteIngredients().Take(5).ToList();

            ingsX.AddMixed();

            var best2 = ingsX.GetConcreteIngredients().Take(5).ToList();
            ingsX.AddWithNoSideEffects();

            var best3 = ingsX.GetConcreteIngredients().Take(5).ToList();

            ingsX.AddMixed();
            var best4 =
                ingsX.GetConcreteIngredients()
                    .GroupBy(i => i.MaxProfit.Item1)
                    .Select(g => new {profit = g.Key, list = g.Distinct().ToList()})
                    .ToList();

            ConcreteIngredient bestest = best4[0].list[0];
            var huh = String.Join(Environment.NewLine, bestest.DerivedFrom.GetOperations());
            var heh = String.Join(Environment.NewLine, (IEnumerable<Effect>) bestest.Effects);

            var hoho = huh + Environment.NewLine + heh;
            ;


            //var mixe = new List<IngredientWithPotential>();

            //var yy = mixe.
            //    SelectMany(i => i.GetPossibleConctetes()).ToList();
            //var yycata =
            //    yy.Where(
            //        i =>
            //            i.Effects.Where(e => e is SideEffect).Cast<SideEffect>().Any(se => se.Catalyst != Catalyst.None))
            //        .ToList();
            //var yyo = yy.
            //    OrderByDescending(c => c.MaxProfit.Item1).ToList();

            //// Remove side effects which can be removed. Mix again.
            //var noSideEffects = mixe.
            //    var
            //concrete = ings.SelectMany(i => i.GetPossibleConctetes()).ToList();

            //var mixed = new List<ConcreteIngredient>();
            //foreach (var ingredient1 in concrete)
            //{
            //    foreach (var ingredient2 in concrete)
            //    {
            //        if (ingredient2 != ingredient1)
            //            mixed.Add(ingredient1.Mix(ingredient2));
            //    }
            //}

            //concrete.AddRange(mixed);

            //mixed = new List<ConcreteIngredient>();
            //foreach (var ingredient1 in concrete)
            //{
            //    foreach (var ingredient2 in concrete)
            //    {
            //        if (ingredient2 != ingredient1)
            //            mixed.Add(ingredient1.Mix(ingredient2));
            //    }
            //}

            //var xx = mixed.OrderByDescending(c => c.MaxProfit.Item1).ToList();
            //var tty = xx.GroupBy(t => t.MaxProfit.Item1).Select(g => new {money = g.Key, items = g.ToList()});
            //foreach (var concreteIngredient in concrete)
            //{
            //    bool hasCatalysts = concreteIngredient.HasRequiredCatalysts();
            //    ;
            //}

            //var baseIngredients = ings.SelectMany(i => i.GetPossibleConctetes());

            //foreach (var ing1 in baseIngredients)
            //{
            //    foreach (var ing2 in baseIngredients)
            //    {
            //        var x = ing1.Combination(ing2).ToList();
            //        if (x.Any())
            //        {
            //            ;
            //        }
            //    }
            //}
        }

        private static void FindSomeMatches(List<IngredientWithPotential> ings)
        {
            foreach (IngredientWithPotential mainIngredient in ings)
            {
                var mainPositiveTrees = mainIngredient.GetPositivEffectTrees().ToList();

                // Find empty trees which can be filled with a positive tree.
                foreach (EffectTree emptyTree in mainIngredient.GetemptyTrees())
                {
                    foreach (IngredientWithPotential matchingIngredient in ings)
                    {
                        // Get positive effect trees which match the main ingredient's empty slots.
                        var initial = matchingIngredient.GetPositivEffectTrees().Where(e => e.Slot == emptyTree.Slot);

                        // Now from those positive trees select effects which are active when any other
                        // effects are active from the main ingredient.
                        foreach (var matchingPositiveTree in initial)
                        {
                            foreach (var matchingEffect in matchingPositiveTree.Effects)
                            {
                                foreach (var mainPositiveTree in mainPositiveTrees)
                                {
                                    foreach (var mainPositiveEffects in mainPositiveTree.Effects)
                                    {
                                        if (matchingEffect.ActiveRange.Overlaps(mainPositiveEffects.ActiveRange))
                                        {
                                            var ingredient1 = mainIngredient;
                                            var emptyTreeMainSlot = emptyTree.Slot;

                                            var ingredient2 = matchingIngredient;
                                            var positiveMathcingTreeSlot = mainPositiveTree.Slot;
                                            var newEffect = matchingEffect;
                                            ;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}