namespace DrinkBotLib.Migrations
{
    using DrinkBotLib.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DrinkBotLib.Model.DrinkBotData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DrinkBotLib.Model.DrinkBotData db)
        {
            User peter = new User { Name = "Peter" };
            db.Users.AddOrUpdate(peter);
            User hannah = new User { Name = "Hannah" };
            db.Users.AddOrUpdate(hannah);
            User pat = new User { Name = "Pat" };
            db.Users.AddOrUpdate(pat);

            db.SaveChanges();

            Ingredient gin = new Ingredient { Name = "Gin", AlcoholByVolume = 40 };
            db.Ingredients.AddOrUpdate(gin);

            Ingredient tonic = new Ingredient { Name = "Tonic Water", AlcoholByVolume = 0 };
            db.Ingredients.AddOrUpdate(tonic);

            Ingredient wine = new Ingredient { Name = "Wine", AlcoholByVolume = 12 };
            db.Ingredients.AddOrUpdate(wine);

            Ingredient milk = new Ingredient { Name = "Milk", AlcoholByVolume = 0 };
            db.Ingredients.AddOrUpdate(milk);

            Ingredient kahlua = new Ingredient { Name = "Kahlua", AlcoholByVolume = 20 };
            db.Ingredients.AddOrUpdate(kahlua);

            Ingredient vodka = new Ingredient { Name = "Vodka", AlcoholByVolume = 40 };
            db.Ingredients.AddOrUpdate(vodka);

            Ingredient whiskey = new Ingredient { Name = "Whiskey", AlcoholByVolume = 40 };
            db.Ingredients.AddOrUpdate(whiskey);

            Ingredient lemon = new Ingredient { Name = "Lemon Juice", AlcoholByVolume = 0 };
            db.Ingredients.AddOrUpdate(lemon);

            Ingredient syrup = new Ingredient { Name = "Simple Syrup", AlcoholByVolume = 0 };

            Recipe gnt = new Recipe { Name = "Gin and Tonic", ImageUrl = @"http://gentlemansjournal.files.wordpress.com/2012/01/gin-and-tonic-fb-1.jpg" };
            db.Recipes.AddOrUpdate(gnt);

            Recipe glassWine = new Recipe { Name = "Glass of Wine", ImageUrl = @"http://www.beirutnightlife.com/wp-content/uploads/2010/11/cheap-wine-glasses-11.jpg" };
            db.Recipes.AddOrUpdate(glassWine);

            Recipe whiteRussian = new Recipe { Name = "White Russian", ImageUrl = @"http://www.eventhireblog.com/wp-content/uploads/2010/07/white-russian.jpg" };
            db.Recipes.AddOrUpdate(whiteRussian);

            Recipe whiskeySour = new Recipe { Name = "Whiskey Sour", ImageUrl = @"http://www.topcocktaildrinks.com/wp-content/uploads/2012/03/whiskey_sour.jpg" };
            db.Recipes.AddOrUpdate(whiskeySour);
            db.SaveChanges();

            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Ingredient = tonic, Recipe = gnt, Amount = 3 });
            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Ingredient = gin, Recipe = gnt, Amount = 1.5M });

            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Ingredient = wine, Recipe = glassWine, Amount = 6 });

            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiteRussian, Ingredient = milk, Amount = 1.5M });
            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiteRussian, Ingredient = vodka, Amount = 3 });
            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiteRussian, Ingredient = kahlua, Amount = 1.5M });

            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiskeySour, Ingredient = whiskey, Amount = 3 });
            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiskeySour, Ingredient = lemon, Amount = 2 });
            db.RecipeIngredients.AddOrUpdate(new RecipeIngredient { Recipe = whiskeySour, Ingredient = syrup, Amount = 1 });

            db.SaveChanges();

            db.Servings.AddOrUpdate(
                new Serving
                {
                    User = peter,
                    Recipe = gnt,
                    Scale = 1,
                    Time = DateTime.Now
                });

            db.Servings.AddOrUpdate(
                new Serving
                {
                    User = peter,
                    Recipe = gnt,
                    Scale = 1,
                    Time = DateTime.Now
                });

            db.SaveChanges();
        }
    }
}
