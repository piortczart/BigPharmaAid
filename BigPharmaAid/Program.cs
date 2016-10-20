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
            var ings = new Ingredients(new[]
            {
                IngredientsInGame.One, IngredientsInGame.Two, IngredientsInGame.Three, IngredientsInGame.Four,
                IngredientsInGame.Five, IngredientsInGame.Six,
                IngredientsInGame.Seven
            });

            ings.AddPossibleTransformations();
            ings.AddPossibleTransformations();
            var ttt1 = ings.IngredientsBla.GroupBy(i => i.Balance).Select(x => new {k = x.Key, l = x.ToList()}).ToList();
            ings.Slim();

            ings.AddMixed();
            ings.Slim();

            ings.AddPossibleTransformations();
            //ings.AddMixed();

            //ings.AddWithNoSideEffects();

            //ings.AddPossibleTransformations();

            ings.Slim();

            var ordered = ings.GetMostLucrative();


            var ttt = ordered.GroupBy(i => i.Balance).Select(x => new {k = x.Key, l = x.ToList()}).ToList();


            var best = ings.GetMostLucrative(4);
            var bestest = best.First();
            ;

            ings.AddMixed();

            ;

            ings.AddWithNoSideEffects();
        }
    }
}