//using System.Collections.Generic;
//using BigPharmaAid.Ingredientz;
//using BigPharmaAid.Ingredientz.Effects;

//namespace BigPharmaAid
//{
//    class Game01
//    {
//        static IngredientWithPotential[] GetIngredients()
//        {
//            var tonite = new IngredientWithPotential(
//                new EffectTree[]
//                {
//                    new SideEffectTree
//                    {
//                        Effect = new SideEffect
//                        {
//                            Name = "Causes Fatigue",
//                            ActiveRange = new IntRange(5, 16),
//                            IsRemovable = true
//                        }
//                    },
//                    new PositiveEffectTree
//                    {
//                        Effects = new List<PositiveEffect>
//                        {
//                            new PositiveEffect(0)
//                            {
//                                Name = "Painkiller",
//                                ActiveRange = new IntRange(5, 12),
//                                Profit = 91,
//                            },
//                            new PositiveEffect(1)
//                            {
//                                Name = "Eases Migrane",
//                                ActiveRange = new IntRange(5, 9),
//                                Profit = 185,
//                            },
//                            new PositiveEffect(2)
//                            {
//                                Name = "Antiseasure",
//                                ActiveRange = new IntRange(11, 15),
//                                Profit = 495,
//                                CatalystRequired = Catalyst.TwoDots
//                            }
//                        }
//                    },
//                    new EmptyTree(),
//                    new EmptyTree()
//                })
//            {
//                Name = "Toneite Essence"
//            };

//            var dos = new IngredientWithPotential(new EffectTree[]
//            {
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Induces Nightmares",
//                        ActiveRange = new IntRange(12, 20),
//                        IsRemovable = false
//                    }
//                },
//                new EmptyTree(),
//                new EmptyTree(),
//                new PositiveEffectTree
//                {
//                    Effects = new List<PositiveEffect>
//                    {
//                        new PositiveEffect(0)
//                        {
//                            Name = "Calms Acid Reflux",
//                            ActiveRange = new IntRange(15, 19),
//                            Profit = 96
//                        },
//                        new PositiveEffect(1)
//                        {
//                            Name = "Alleviates Stomach Ulcers",
//                            ActiveRange = new IntRange(8, 12),
//                            Profit = 265
//                        },
//                        new PositiveEffect(2)
//                        {
//                            Name = "Appetite Supressant",
//                            ActiveRange = new IntRange(11, 14),
//                            Profit = 511
//                        }
//                    }
//                }
//            })
//            {
//                Name = "Harpilic Concentration",
//            };

//            var wicko = new IngredientWithPotential(new EffectTree[]
//            {
//                new PositiveEffectTree
//                {
//                    Effects = new List<PositiveEffect>
//                    {
//                        new PositiveEffect(0)
//                        {
//                            Name = "Soothes Cold Symptoms",
//                            ActiveRange = new IntRange(3, 10),
//                            Profit = 120
//                        },
//                        new PositiveEffect(1)
//                        {
//                            Name = "Antibiotic",
//                            ActiveRange = new IntRange(12, 18),
//                            Profit = 236
//                        }
//                    }
//                },
//                new SideEffectTree
//                {
//                    Effect =
//                        new SideEffect
//                        {
//                            Name = "Causes pins ...",
//                            ActiveRange = new IntRange(3, 14),
//                            IsRemovable = true
//                        }
//                },
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Causes Headaches",
//                        ActiveRange = new IntRange(4, 12),
//                        IsRemovable = false
//                    }
//                },
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Causes Random Faining",
//                        ActiveRange = new IntRange(2, 12),
//                        IsRemovable = true,
//                        Catalyst = Catalyst.TwoDots
//                    }
//                }
//            })
//            {
//                Name = "Wickocide Mist",
//            };

//            var ferr = new IngredientWithPotential(
//                new EffectTree[]
//                {
//                    new SideEffectTree
//                    {
//                        Effect = new SideEffect
//                        {
//                            Name = "Induces Nausea",
//                            ActiveRange = new IntRange(6, 14),
//                            IsRemovable = false
//                        }
//                    },
//                    new PositiveEffectTree
//                    {
//                        Effects = new List<PositiveEffect>
//                        {
//                            new PositiveEffect(0)
//                            {
//                                Name = "Removes Warts",
//                                ActiveRange = new IntRange(11, 16),
//                                Profit = 94
//                            },
//                            new PositiveEffect(1)
//                            {
//                                Name = "Female Contraceptive",
//                                ActiveRange = new IntRange(2, 6),
//                                Profit = 267
//                            }
//                        }
//                    },
//                    new SideEffectTree
//                    {
//                        Effect = new SideEffect
//                        {
//                            Name = "Dries Mouth",
//                            ActiveRange = new IntRange(2, 10),
//                            IsRemovable = false
//                        }
//                    },
//                    new SideEffectTree
//                    {
//                        Effect = new SideEffect
//                        {
//                            Name = "Causes Constipation",
//                            ActiveRange = new IntRange(3, 11),
//                            IsRemovable = true
//                        }
//                    }
//                })
//            {
//                Name = "Ferrixy ...",
//            };

//            var africa = new IngredientWithPotential(new EffectTree[]
//            {
//                new PositiveEffectTree
//                {
//                    Effects = new List<PositiveEffect>
//                    {
//                        new PositiveEffect(0)
//                        {
//                            Name = "Antidepressant",
//                            ActiveRange = new IntRange(15, 20),
//                            Profit = 109
//                        },
//                        new PositiveEffect(1)
//                        {
//                            Name = "Combats ADHD",
//                            ActiveRange = new IntRange(16, 20),
//                            Profit = 338,
//                            CatalystRequired = Catalyst.TwoDots
//                        }
//                    }
//                },
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Inflames Skin",
//                        ActiveRange = new IntRange(10, 18),
//                        IsRemovable = false
//                    }
//                },
//                new EmptyTree(),
//                new EmptyTree()
//            })
//            {
//                Name = "Yupachurn Steam"
//            };

//            var malleable = new IngredientWithPotential(new EffectTree[]
//            {
//                new PositiveEffectTree
//                {
//                    Effects = new List<PositiveEffect>
//                    {
//                        new PositiveEffect(0)
//                        {
//                            Name = "Soothes Cought",
//                            ActiveRange = new IntRange(6, 13),
//                            Profit = 102
//                        },
//                        new PositiveEffect(1)
//                        {
//                            Name = "Eases Asthma",
//                            ActiveRange = new IntRange(4, 10),
//                            Profit = 230
//                        },
//                        new PositiveEffect(2)
//                        {
//                            Name = "Treats Bronchitis",
//                            ActiveRange = new IntRange(6, 11),
//                            Profit = 497,
//                            CatalystRequired = Catalyst.TwoDots
//                        },
//                        new PositiveEffect(3)
//                        {
//                            Name = "Cures Tuburculosis",
//                            ActiveRange = new IntRange(1, 2),
//                            Profit = 1012
//                        }
//                    }
//                },
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Encourages Anxiety",
//                        ActiveRange = new IntRange(5, 17),
//                        IsRemovable = true,
//                        Catalyst = Catalyst.TwoDots
//                    }
//                },
//                new EmptyTree(),
//                new SideEffectTree
//                {
//                    Effect = new SideEffect
//                    {
//                        Name = "Prompts Sleepiness",
//                        ActiveRange = new IntRange(1, 13),
//                        IsRemovable = true
//                    }
//                }
//            })
//            {
//                Name = "Malleable Bipoxy Crystal"
//            };

//            return new[]
//            {
//                malleable,
//                africa,
//                dos,
//                ferr,
//                tonite,
//                wicko
//            };
//        }
//    }
//}