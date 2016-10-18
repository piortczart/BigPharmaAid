using System;
using System.Collections.Generic;
using System.Linq;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid.Ingredientz
{
    class IngredientWithPotential
    {
        public IngredientOperations Operations { get; }
        public EffectTree[] EffectTreesPossible { get; }
        public int[] CurrentEffectLevels { get; }

        public Effect[] CurrentEffects
            => CurrentEffectLevels.Select((l, i) => EffectTreesPossible[i].GetEffects()[l]).ToArray();

        public string Name { get; }
        public int Level { get; }
        public int BaseCost { get; }

        public int Profit => GetPositiveEffects().Where(e => e.ActiveRange.Contains(Level)).Sum(e => e.Profit);
        public int Balance => Profit - Operations.Cost - BaseCost;

        public IngredientWithPotential(string name, int startingLevel, int baseCost, EffectTree[] effectTrees,
            int[] currentEffectlevels = null, IngredientOperations operations = null)
        {
            if (effectTrees.Length != 4)
            {
                throw new ArgumentException("Needs to have exactly 4 effect trees.", nameof(effectTrees));
            }

            Level = startingLevel;
            BaseCost = baseCost;
            Name = name;
            Operations = operations ?? new IngredientOperations(null);

            EffectTreesPossible = effectTrees;
            for (int i = 0; i < effectTrees.Length; i++)
            {
                EffectTreesPossible[i].SetSlot(i);
            }

            // Current effects are the actual effects which this ingredient has right now.
            // At start it has the first effects from all trees.
            CurrentEffectLevels = currentEffectlevels ?? new[] {0, 0, 0, 0};
        }

        public IEnumerable<IngredientWithPotential> GetPossibleTransformations(bool includeThis = true)
        {
            if (includeThis)
            {
                yield return this;
            }

            foreach (var immediateResult in GetPossibleImmediateUpgrades().ToList())
            {
                yield return immediateResult;

                var nestedResults = immediateResult.GetPossibleImmediateUpgrades().ToList();
                foreach (var nestedResult in nestedResults)
                {
                    yield return nestedResult;
                }
            }
        }

        private static int GetLevelChangeToAttain(int baseLevel, IntRange desiredRange)
        {
            int levelChange = 0;
            if (baseLevel < desiredRange.From)
            {
                // Level too low? Need to increase it.
                levelChange = desiredRange.From - baseLevel;
            }
            else if (baseLevel > desiredRange.To)
            {
                // Level too high? Need to decrease it.
                levelChange = desiredRange.To - baseLevel;
            }
            return levelChange;
        }

        public bool HasCatalyst(Catalyst catalyst)
        {
            foreach (SideEffect sideEffect in GetSideEffects())
            {
                if (sideEffect.Catalyst == catalyst)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<IngredientWithPotential> GetPossibleImmediateUpgrades()
        {
            // ONLY POSITIVE EFFECTS CAN BE TRANSFORMED (UPGRADED)
            for (int i = 0; i < EffectTreesPossible.Length; i++)
            {
                Effect currentEffect = CurrentEffects[i];

                Effect possibleEffect =
                    EffectTreesPossible[i].GetEffects().Skip(CurrentEffectLevels[i] + 1).FirstOrDefault();
                // Are there any options to improve at this index?
                if (possibleEffect != null)
                {
                    var newOperations = new IngredientOperations(Operations);

                    PositiveEffect currentPositive = currentEffect as PositiveEffect;
                    if (currentPositive != null)
                    {
                        EffectUpgradeRequirement requirement = currentPositive.Requirement;

                        // It is not known how to update this (yet).
                        if (requirement == EffectUpgradeRequirement.Unknown)
                        {
                            continue;
                        }

                        // We don't have the required catalyst?
                        if (requirement.Catalyst != Catalyst.None && !HasCatalyst(requirement.Catalyst))
                        {
                            continue;
                        }

                        int currentLevel = Level;

                        // The concentration might need a change in order to be upgraded.
                        int levelChangeUno = GetLevelChangeToAttain(currentLevel, requirement.Concentration);
                        if (levelChangeUno != 0)
                        {
                            newOperations.Add(IngredientOperation.GetLevelChange(levelChangeUno));
                        }

                        currentLevel += levelChangeUno;

                        // The upgrade process changes the concentration.
                        int levelAfterUpgrade = requirement.Machine.ChangeLevel(currentLevel);
                        int levelChangeDos = levelAfterUpgrade - currentLevel;
                        currentLevel = levelAfterUpgrade;
                        if (levelChangeDos != 0)
                        {
                            newOperations.Add(IngredientOperation.GetLevelChange(levelChangeDos, requirement.Machine));
                        }

                        // Update the new effect level (of the selected effect)
                        int[] newEffectLevels = CurrentEffectLevels.ToArray();
                        newEffectLevels[i]++;

                        // UPGRADE DONE.

                        // This is an iupdated ingredient which might not have the proper concentration
                        // for the upgraded effect to be active.
                        yield return
                            new IngredientWithPotential(Name, currentLevel, BaseCost, EffectTreesPossible,
                                newEffectLevels, newOperations);

                        // Change the concentration to acctivate the upgraded effect.
                        int levelChangeTres = GetLevelChangeToAttain(currentLevel, possibleEffect.ActiveRange);
                        if (levelChangeTres != 0)
                        {
                            newOperations.Add(IngredientOperation.GetLevelChange(levelChangeTres));
                            currentLevel += levelChangeTres;

                            yield return
                                new IngredientWithPotential(Name, currentLevel, BaseCost,
                                    EffectTreesPossible, newEffectLevels, newOperations);
                        }
                    }
                }
            }
        }

        public IEnumerable<EffectTree> GetemptyTrees()
        {
            return EffectTreesPossible.Where(t => t is EmptyEffectTree);
        }

        public IEnumerable<PositiveEffect> GetPositiveEffects()
        {
            return CurrentEffects.Where(e => e is PositiveEffect).Cast<PositiveEffect>();
        }

        public IEnumerable<PositiveEffectTree> GetPositiveEffectTrees()
        {
            return EffectTreesPossible.Where(t => t is PositiveEffectTree).Cast<PositiveEffectTree>();
        }

        public IEnumerable<SideEffect> GetSideEffects()
        {
            return CurrentEffects.Where(t => t is SideEffect).Cast<SideEffect>();
        }

        public IEnumerable<SideEffectTree> GetSideEffectTrees()
        {
            return EffectTreesPossible.Where(t => t is SideEffectTree).Cast<SideEffectTree>();
        }

        private IngredientWithPotential Clone(IngredientOperation operation, int newLevel)
        {
            return new IngredientWithPotential(
                Name,
                newLevel,
                BaseCost,
                EffectTreesPossible.ToArray(),
                CurrentEffectLevels.ToArray(),
                new IngredientOperations(Operations, operation));
        }

        public IngredientWithPotential Mix(IngredientWithPotential other)
        {
            // The base has no free slots? Result will be the base.
            if (!EffectTreesPossible.Any(e => e is EmptyEffectTree))
            {
                return this;
            }

            var result = Clone(IngredientOperation.GetMixing(new List<IngredientWithPotential> {this, other}), Level);
            for (int i = 0; i < result.EffectTreesPossible.Length; i++)
            {
                if (result.EffectTreesPossible[i] is EmptyEffectTree)
                {
                    result.EffectTreesPossible[i] = other.EffectTreesPossible[i];
                }
            }
            return result;
        }

        public IEnumerable<IngredientWithPotential> GetWithoutSideEffects(bool includeThis)
        {
            if (includeThis)
            {
                yield return this;
            }

            // No removable side effects? Nothing to do here.
            if (GetSideEffectTrees().All(t => t.Effect.EffectRemoval == EffectRemoval.Impossible))
            {
                yield break;
            }

            int effectsRemoved;
            for (int i = 0; i < (EffectTreesPossible[0] is SideEffectTree ? 2 : 1); i++)
            {
                var eff0 = i == 0 ? EffectTreesPossible[0] : new EmptyEffectTree();
                int levelsChange0 = 0;
                if (i == 1)
                {
                    var sideEffectremoved = (EffectTreesPossible[0] as SideEffectTree).Effect;
                    int localLevel = Level;
                    levelsChange0 = GetLevelChangeToAttain(localLevel, sideEffectremoved.EffectRemoval.RemovalRange);
                }

                for (int j = 0; j < (EffectTreesPossible[1] is SideEffectTree ? 2 : 1); j++)
                {
                    var eff1 = j == 0 ? EffectTreesPossible[1] : new EmptyEffectTree();
                    int levelsChange1 = 0;
                    if (j == 1)
                    {
                        var sideEffectremoved = (EffectTreesPossible[1] as SideEffectTree).Effect;
                        int localLevel = Level + levelsChange0;
                        levelsChange1 = GetLevelChangeToAttain(localLevel, sideEffectremoved.EffectRemoval.RemovalRange);
                    }

                    for (int k = 0; k < (EffectTreesPossible[2] is SideEffectTree ? 2 : 1); k++)
                    {
                        var eff2 = k == 0 ? EffectTreesPossible[2] : new EmptyEffectTree();
                        int levelsChange2 = 0;
                        if (k == 1)
                        {
                            var sideEffectremoved = (EffectTreesPossible[2] as SideEffectTree).Effect;
                            int localLevel = Level + levelsChange0 + levelsChange1;
                            levelsChange2 = GetLevelChangeToAttain(localLevel,
                                sideEffectremoved.EffectRemoval.RemovalRange);
                        }

                        for (int l = 0; l < (EffectTreesPossible[3] is SideEffectTree ? 2 : 1); l++)
                        {
                            var eff3 = l == 0 ? EffectTreesPossible[3] : new EmptyEffectTree();
                            if (i == 0 && j == 0 && k == 0 && l == 0)
                            {
                                continue;
                            }
                            int levelsChange3 = 0;
                            if (l == 1)
                            {
                                var sideEffectremoved = (EffectTreesPossible[3] as SideEffectTree).Effect;
                                int localLevel = Level + levelsChange0 + levelsChange1 + levelsChange2;
                                levelsChange3 = GetLevelChangeToAttain(localLevel,
                                    sideEffectremoved.EffectRemoval.RemovalRange);
                            }

                            var finalLevel = Level + levelsChange0 + levelsChange1 + levelsChange2 + levelsChange3;
                            effectsRemoved = i + j + k + l;

                            List<int> levelsChange =
                                new[] {levelsChange0, levelsChange1, levelsChange2, levelsChange3}.Where(lol => lol != 0)
                                    .ToList();

                            var result = Clone(IngredientOperation.GetSideEffectRemoval(levelsChange, effectsRemoved),
                                finalLevel);
                            result.EffectTreesPossible[0] = eff0;
                            result.EffectTreesPossible[1] = eff1;
                            result.EffectTreesPossible[2] = eff2;
                            result.EffectTreesPossible[3] = eff3;

                            yield return result;
                        }
                    }
                }
            }
        }

        public override string ToString()
        {
            return $"IWP: {Name} ({Balance}({Profit}), {String.Join(",", (IEnumerable<Effect>) CurrentEffects)})";
        }
    }
}