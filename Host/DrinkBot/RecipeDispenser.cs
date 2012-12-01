using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DrinkBotLib
{
    public class RecipeDispenser
    {
        public IEnumerable<Recipe> Recipes
        {
            get
            {
                database.Recipes.Load();
                return database.Recipes.Local;  
            }
        }

        public IEnumerable<User> Users
        {
            get
            {

                database.Users.Load();
                return database.Users.Local;
            }
        }

        private ILiquidDispenser dispenser;
        public  DrinkBotData database;

        public RecipeDispenser(ILiquidDispenser dispenser)
        {
            this.dispenser = dispenser;
            this.database = new DrinkBotData();
            
        }

        public void Dispense(Recipe recipe, User user, decimal scale = 1)
        {
            AddServing(recipe, user, scale);
            Dispense(recipe, (double)scale);
        }

        public void Dispense(Recipe recipe, double scale = 1)
        {
            foreach (var ing in recipe.Ingredients)
                Dispense(ing.Ingredient, (double) ing.Amount * scale);
        }

        public void Dispense(Ingredient ingredient, double amount)
        {
            dispenser.Dispense(ingredient.Name, amount);
        }

        public bool CanDispense(Recipe recipe)
        {
            return recipe.Ingredients.Select(i => i.Ingredient).All(CanDispense);
        }

        public bool CanDispense(Ingredient i)
        {
            return dispenser.CanDispense(i.Name);
        }

        public void AddServing(Recipe recipe, User user, decimal scale = 1)
        {
            database.Servings.Add(
                new Serving
                {
                    User = user,
                    Recipe = recipe,
                    Scale = scale,
                    Time = DateTime.Now
                });
            database.SaveChanges();
        }
    }
}
