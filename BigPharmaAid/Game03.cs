using System.Collections.Generic;
using BigPharmaAid.Ingredientz;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid
{
    class Game03
    {
        public static IngredientWithPotential[] GetIngredients()
        {
            var one = new IngredientWithPotential(
                "Green Poo",
                12,
                37,
                new EffectTree[]
                {
                    new EmptyEffectTree(),
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.CausesFatigue,
                            ActiveRange = new IntRange(5, 16),
                            EffectRemoval = new EffectRemoval(new IntRange(4, 8))
                        }
                    },
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0, new EffectUpgradeRequirement(new IntRange(4, 8), Machine.Agglomerator))
                            {
                                Type = EffectTypes.SoothesColdSymptoms,
                                ActiveRange = new IntRange(3, 10),
                                Profit = 95
                            },
                            new PositiveEffect(1,
                                new EffectUpgradeRequirement(new IntRange(6, 11), Machine.CyroCondenser,
                                    Catalyst.ThreeDots))
                            {
                                Type = EffectTypes.Antibiotic,
                                ActiveRange = new IntRange(12, 18),
                                Profit = 230
                            },
                            new PositiveEffect(2, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.Antimalarial,
                                ActiveRange = new IntRange(11, 16),
                                Profit = 416,
                            }
                        }
                    },
                    new EmptyEffectTree()
                });

            var two = new IngredientWithPotential(
                "Purple Flask",
                7,
                37,
                new EffectTree[]
                {
                    new EmptyEffectTree(),
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0, new EffectUpgradeRequirement(new IntRange(0, 6), Machine.Ioniser))
                            {
                                Type = EffectTypes.RelievesHypertension,
                                ActiveRange = new IntRange(9, 13),
                                Profit = 107
                            },
                            new PositiveEffect(1, new EffectUpgradeRequirement(new IntRange(9, 14), Machine.Autoclave))
                            {
                                Type = EffectTypes.TreatsAngina,
                                ActiveRange = new IntRange(6, 12),
                                Profit = 233
                            },
                            new PositiveEffect(2, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.ReducesStrokeRisk,
                                ActiveRange = new IntRange(10, 15),
                                Profit = 534,
                            }
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.PromptsSleepiness,
                            ActiveRange = new IntRange(1, 13),
                            EffectRemoval = new EffectRemoval(new IntRange(14, 19))
                        }
                    },
                    new EmptyEffectTree()
                }
                );

            var three = new IngredientWithPotential(
                "Green Cube",
                14,
                34,
                new EffectTree[]
                {
                    new EmptyEffectTree(),
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.InducesNausea,
                            ActiveRange = new IntRange(6, 14),
                        }
                    },
                    new EmptyEffectTree(),
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0,
                                new EffectUpgradeRequirement(new IntRange(7, 11), Machine.Dissolver, Catalyst.TwoDots))
                            {
                                Type = EffectTypes.Antidepressant,
                                ActiveRange = new IntRange(15, 20),
                                Profit = 118
                            },
                            new PositiveEffect(1,
                                new EffectUpgradeRequirement(new IntRange(12, 14), Machine.Ioniser, Catalyst.ThreeDots))
                            {
                                Type = EffectTypes.CombatsAdhd,
                                ActiveRange = new IntRange(15, 20),
                                Profit = 391,
                            },
                            new PositiveEffect(2, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.TreatsBipolarDisorder,
                                ActiveRange = new IntRange(15, 20),
                                Profit = 664,
                            }
                        }
                    }
                });

            var four = new IngredientWithPotential(
                "Yellow Diamond",
                14,
                35,
                new EffectTree[]
                {
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0, new EffectUpgradeRequirement(new IntRange(16, 18), Machine.Evaporator))
                            {
                                Type = EffectTypes.CalmsAcidReflux,
                                ActiveRange = new IntRange(15, 19),
                                Profit = 112
                            },
                            new PositiveEffect(1, new EffectUpgradeRequirement(new IntRange(6, 8), Machine.Autoclave))
                            {
                                Type = EffectTypes.AlleviatesStomachUlcers,
                                ActiveRange = new IntRange(8, 12),
                                Profit = 219
                            },
                            new PositiveEffect(2, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.AppetiteSuppressant,
                                ActiveRange = new IntRange(11, 15),
                                Profit = 575
                            }
                        }
                    },
                    new EmptyEffectTree(),
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.CausesPinsAndNeedles,
                            ActiveRange = new IntRange(3, 14),
                            EffectRemoval = new EffectRemoval(new IntRange(3, 4))
                        }
                    },
                    new EmptyEffectTree(),
                });

            var five = new IngredientWithPotential(
                "Purple Extinguisher",
                10,
                35,
                new EffectTree[]
                {
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0,
                                new EffectUpgradeRequirement(new IntRange(6, 8), Machine.Dissolver, Catalyst.TwoDots))
                            {
                                Type = EffectTypes.PreventsGout,
                                ActiveRange = new IntRange(5, 9),
                                Profit = 82
                            },
                            new PositiveEffect(1, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.CombatsLiverDisease,
                                ActiveRange = new IntRange(16, 19),
                                Profit = 391
                            }
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.IncreasesBloodPressure,
                            ActiveRange = new IntRange(8, 16),
                            EffectRemoval = EffectRemoval.Impossible
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect(Catalyst.TwoDots)
                        {
                            Type = EffectTypes.CausesRandomFainting,
                            ActiveRange = new IntRange(2, 12),
                            EffectRemoval = new EffectRemoval(new IntRange(12, 14)),
                        }
                    },
                    new EmptyEffectTree(),
                }
                );

            var six = new IngredientWithPotential(
                "Red Poo",
                9,
                35,
                new EffectTree[]
                {
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.InflamesSkin,
                            ActiveRange = new IntRange(10, 18),
                            EffectRemoval = EffectRemoval.Impossible
                        }
                    },
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0, new EffectUpgradeRequirement(new IntRange(13, 15), Machine.Ioniser))
                            {
                                Type = EffectTypes.RemovesWarts,
                                ActiveRange = new IntRange(11, 16),
                                Profit = 89
                            },
                            new PositiveEffect(1, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.FemaleContraceptive,
                                ActiveRange = new IntRange(1, 6),
                                Profit = 228
                            }
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.CausesConstipation,
                            ActiveRange = new IntRange(3, 11),
                            EffectRemoval = new EffectRemoval(new IntRange(13, 17))
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect(Catalyst.ThreeDots)
                        {
                            Type = EffectTypes.CausesBreathingDifficulties,
                            ActiveRange = new IntRange(6, 15),
                            EffectRemoval = new EffectRemoval(new IntRange(17, 20))
                        }
                    }
                });

            var seven = new IngredientWithPotential(
                "Purple Crystals",
                14,
                36,
                new EffectTree[]
                {
                    new SideEffectTree
                    {
                        Effect = new SideEffect(Catalyst.TwoDots)
                        {
                            Type = EffectTypes.EncouragesAnxiety,
                            ActiveRange = new IntRange(5, 17),
                            EffectRemoval = new EffectRemoval(new IntRange(1, 5))
                        }
                    },
                    new SideEffectTree
                    {
                        Effect = new SideEffect
                        {
                            Type = EffectTypes.DriesMouth,
                            ActiveRange = new IntRange(2, 10),
                            EffectRemoval = EffectRemoval.Impossible
                        }
                    },
                    new PositiveEffectTree
                    {
                        Effects = new List<PositiveEffect>
                        {
                            new PositiveEffect(0, new EffectUpgradeRequirement(new IntRange(7, 10), Machine.Evaporator))
                            {
                                Type = EffectTypes.Painkiller,
                                ActiveRange = new IntRange(5, 12),
                                Profit = 95,
                            },
                            new PositiveEffect(1, EffectUpgradeRequirement.Unknown)
                            {
                                Type = EffectTypes.EasesMigrane,
                                ActiveRange = new IntRange(5, 9),
                                Profit = 189,
                            }
                        }
                    },
                    new EmptyEffectTree(),
                });

            return new[]
            {
                one, two, three, four, five, six, seven
            };
        }
    }
}