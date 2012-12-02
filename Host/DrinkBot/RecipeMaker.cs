using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib
{
    public class RecipeDispenser
    {
        private ILiquidDispenser dispenser;
        private DrinkBotEntities database;

        public RecipeDispenser(ILiquidDispenser dispenser)
        {
            this.dispenser = dispenser;
            database = new DrinkBotEntities();
        }

        public void Dispense(string recipeName, double scale = 1)
        {
            Dispense(database.Recipes.Single(r => r.Name == recipeName), scale);
        }

        public void Dispense(IEnumerable<KeyValuePair<Ingredient, double>> recipe, double scale = 1)
        {
            foreach (var ing in recipe)
                Dispense(ing.Key, ing.Value * scale);
        }

        public void Dispense(Ingredient ingredient, double amount)
        {
            dispenser.Dispense(ingredient.Name, amount);
        }

        public bool CanDispense(IEnumerable<KeyValuePair<Ingredient,double>> recipe)
        {
            return recipe.Select(kv => kv.Key).All(CanDispense);
        }

        public bool CanDispense(Ingredient i)
        {
            return dispenser.CanDispense(i.Name);
        }
    }
}
