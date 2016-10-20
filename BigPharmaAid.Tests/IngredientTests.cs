using System;
using BigPharmaAid.Ingredientz;
using BigPharmaAid.Ingredientz.Effects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BigPharmaAid.Tests
{
    [TestClass]
    public class IngredientTests
    {
        [TestMethod]
        public void Ingredient_Equals_Test()
        {
            var a = IngredientsInGame.One.Clone(IngredientOperation.GetLevelChange(1), IngredientsInGame.One.Level);
            var b = IngredientsInGame.One.Clone(IngredientOperation.GetLevelChange(1), IngredientsInGame.One.Level);

            Assert.IsTrue(a.Equals(b));

            // It was empty and should still be equal.
            b.EffectTreesPossible[0] = EmptyEffectTree.Empty;
            Assert.IsTrue(a.Equals(b));

            // Now they should not be equal :)
            b.EffectTreesPossible[1] = EmptyEffectTree.Empty;
            Assert.IsFalse(a.Equals(b));
        }
    }
}