﻿using System.Collections.Generic;
using BigPharmaAid.Ingredientz;
using BigPharmaAid.Ingredientz.Effects;

namespace BigPharmaAid
{
    class Game02
    {
        public static IngredientWithPotential[] GetIngredients()
        {
            return new[]
            {
                //
                // FIRST (Blue)
                //
                new IngredientWithPotential(
                    "Mellable Crystals",
                    1,
                    new EffectTree[]
                    {
                        new EmptyEffectTree(),
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Sleepiness",
                                ActiveRange = new IntRange(1, 13),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new EmptyEffectTree(),
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Removes Warts",
                                    ActiveRange = new IntRange(13, 15),
                                    Profit = 94
                                },
                                new PositiveEffect(1)
                                {
                                    Name = "Female Contraceptive",
                                    ActiveRange = new IntRange(2, 6),
                                    Profit = 228
                                }
                            }
                        }
                    }),
                //
                // SECOND (Pink)
                //
                new IngredientWithPotential(
                    "Yupoxin",
                    1,
                    new EffectTree[]
                    {
                        new EmptyEffectTree(),
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Blood Pressure",
                                ActiveRange = new IntRange(8, 16),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new EmptyEffectTree(),
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Antihistamine",
                                    ActiveRange = new IntRange(2, 8),
                                    Profit = 92,
                                },
                                new PositiveEffect(1)
                                {
                                    Name = "Alleviates Insomnia",
                                    ActiveRange = new IntRange(12, 16),
                                    Profit = 270
                                },
                                new PositiveEffect(2)
                                {
                                    Name = "Reduces Anxiety",
                                    ActiveRange = new IntRange(2, 6),
                                    Profit = 777
                                }
                            }
                        }
                    }),
                //
                // THIRD (Green)
                //
                new IngredientWithPotential(
                    "Moist Grub Grub (Bofon Steam)",
                    1,
                    new EffectTree[]
                    {
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Prevent Gout",
                                    ActiveRange = new IntRange(5, 9),
                                    Profit = 115,
                                },
                                new PositiveEffect(1)
                                {
                                    Name = "Combats Liver Disease",
                                    ActiveRange = new IntRange(16, 19),
                                    Profit = 442,
                                    CatalystRequired = Catalyst.TwoDots
                                }
                            }
                        },
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Sleepiness",
                                ActiveRange = new IntRange(1, 13),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new EmptyEffectTree(),
                        new EmptyEffectTree()
                    }),
                //
                // Fourth (Yellow)
                //
                new IngredientWithPotential(
                    "Reacted Liquid",
                    1,
                    new EffectTree[]
                    {
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Narrows Pupils",
                                ActiveRange = new IntRange(1, 8),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new SideEffectTree
                        {
                            Effect = new SideEffect(Catalyst.TwoDots)
                            {
                                Name = "Blurs Vision",
                                ActiveRange = new IntRange(3, 11),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new SideEffectTree
                        {
                            Effect = new SideEffect(Catalyst.ThreeDots)
                            {
                                Name = "Induces Vomiting",
                                ActiveRange = new IntRange(1, 12),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Calms Acid Reflux",
                                    ActiveRange = new IntRange(15, 19),
                                    Profit = 108,
                                },
                                new PositiveEffect(1)
                                {
                                    Name = "Alleviates Stomach Ulcers",
                                    ActiveRange = new IntRange(8, 12),
                                    Profit = 211,
                                }
                            }
                        }
                    }),
                //
                // FIFTH (Purple minerals)
                //
                new IngredientWithPotential(
                    "Sour Pangsat",
                    1,
                    new EffectTree[]
                    {
                        new EmptyEffectTree(),
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Inflames Skin",
                                ActiveRange = new IntRange(10, 18),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new EmptyEffectTree(),
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Treats Diabetes",
                                    ActiveRange = new IntRange(1, 5),
                                    Profit = 107,
                                }
                            }
                        },
                    }),
                //
                // Cyan (pink) bottle.
                //
                new IngredientWithPotential(
                    "Lipocide Tincture (Cyan Bottle)",
                    1,
                    new EffectTree[]
                    {
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Causes Constipation",
                                ActiveRange = new IntRange(3, 11),
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new EmptyEffectTree(),
                        new EmptyEffectTree(),
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Soothes Rash",
                                    ActiveRange = new IntRange(8, 12),
                                    Profit = 104,
                                    CatalystRequired = Catalyst.TwoDots
                                }
                            }
                        }
                    }),
                new IngredientWithPotential(
                    "Poo",
                    1,
                    new EffectTree[]
                    {
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Dries Mouth",
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new PositiveEffectTree
                        {
                            Effects = new List<PositiveEffect>
                            {
                                new PositiveEffect(0)
                                {
                                    Name = "Painkiller",
                                    ActiveRange = new IntRange(5, 12),
                                    Profit = 96,
                                },
                                new PositiveEffect(1)
                                {
                                    Name = "Eases Migrane",
                                    ActiveRange = new IntRange(5, 9),
                                    Profit = 194
                                }
                            }
                        },
                        new SideEffectTree
                        {
                            Effect = new SideEffect(Catalyst.TwoDots)
                            {
                                Name = "Anxiety",
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        },
                        new SideEffectTree
                        {
                            Effect = new SideEffect
                            {
                                Name = "Headaches",
                                EffectRemoval = new EffectRemoval(new IntRange(5,10))
                            }
                        }
                    }),
            };
        }
    }
}