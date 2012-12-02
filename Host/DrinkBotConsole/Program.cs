using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrinkBotLib;
using DrinkBotLib.Model;


namespace DrinkBotConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            RecipeDispenser rd = new RecipeDispenser(new DummyDispenser());
            DrinkBotData db = rd.database;

            //db.Database.Delete();
            //db.Database.CreateIfNotExists();
            LoadTestData(db);

            foreach (var user in db.Users)
            {
                System.Console.WriteLine("{0}({1})", user.Name, user.ID);
            }

            foreach (var r in rd.Recipes)
            {
                System.Console.WriteLine(r);
                foreach (var i in r.Ingredients)
                {
                    System.Console.WriteLine("\t{0}", i);
                }
            }

            
            System.Console.WriteLine("Done");
            System.Console.ReadKey(false);


            
        }

        public static void LoadTestData(DrinkBotData db)
        {
            

            User peter = new User { Name = "Peter" };
            peter = db.Users.Add(peter);
            User hannah = new User { Name = "Hannah" };
            hannah = db.Users.Add(hannah);
            User pat = new User { Name = "Pat" };
            pat = db.Users.Add(pat);
            
            db.SaveChanges();

            Ingredient gin = new Ingredient { Name = "Gin", AlcoholByVolume = 40 };
            gin = db.Ingredients.Add(gin);

            Ingredient tonic = new Ingredient { Name = "Tonic Water", AlcoholByVolume = 0 };
            tonic = db.Ingredients.Add(tonic);

            Ingredient wine = new Ingredient { Name = "Wine", AlcoholByVolume = 12 };
            wine = db.Ingredients.Add(wine);

            Ingredient milk = new Ingredient { Name = "Milk", AlcoholByVolume = 0 };
            milk = db.Ingredients.Add(milk);

            Ingredient kahlua = new Ingredient { Name = "Kahlua", AlcoholByVolume = 20 };
            kahlua = db.Ingredients.Add(kahlua);

            Ingredient vodka = new Ingredient { Name = "Vodka", AlcoholByVolume = 40 };
            vodka = db.Ingredients.Add(vodka);

            Ingredient whiskey = new Ingredient { Name = "Whiskey", AlcoholByVolume = 40 };
            whiskey = db.Ingredients.Add(whiskey);

            Ingredient lemon = new Ingredient { Name = "Lemon Juice", AlcoholByVolume = 0 };
            lemon = db.Ingredients.Add(lemon);

            Ingredient syrup = new Ingredient { Name = "Simple Syrup", AlcoholByVolume = 0 };

            Recipe gnt = new Recipe { Name = "Gin and Tonic", ImageUrl=@"http://gentlemansjournal.files.wordpress.com/2012/01/gin-and-tonic-fb-1.jpg"};
            gnt = db.Recipes.Add(gnt);

            Recipe glassWine = new Recipe { Name = "Glass of Wine", ImageUrl = @"http://www.beirutnightlife.com/wp-content/uploads/2010/11/cheap-wine-glasses-11.jpg" };
            glassWine = db.Recipes.Add(glassWine);

            Recipe whiteRussian = new Recipe { Name = "White Russian", ImageUrl = @"http://www.eventhireblog.com/wp-content/uploads/2010/07/white-russian.jpg" };
            whiteRussian = db.Recipes.Add(whiteRussian);

            Recipe whiskeySour = new Recipe { Name = "Whiskey Sour", ImageUrl = @"http://www.topcocktaildrinks.com/wp-content/uploads/2012/03/whiskey_sour.jpg" };
            whiskeySour = db.Recipes.Add(whiskeySour);
            db.SaveChanges();

            db.RecipeIngredients.Add(new RecipeIngredient { Ingredient = tonic, Recipe = gnt, Amount = 3 });
            db.RecipeIngredients.Add(new RecipeIngredient { Ingredient = gin, Recipe = gnt, Amount = 1.5M });

            db.RecipeIngredients.Add(new RecipeIngredient { Ingredient = wine, Recipe = glassWine, Amount = 6});

            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiteRussian, Ingredient = milk, Amount = 1.5M});
            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiteRussian, Ingredient = vodka, Amount = 3});
            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiteRussian, Ingredient = kahlua, Amount = 1.5M});

            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiskeySour, Ingredient = whiskey , Amount = 3});
            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiskeySour, Ingredient = lemon, Amount = 2});
            db.RecipeIngredients.Add(new RecipeIngredient { Recipe = whiskeySour, Ingredient = syrup, Amount = 1});

            db.SaveChanges();

            db.Servings.Add(
                new Serving
                {
                    User = peter,
                    Recipe = gnt,
                    Scale = 1,
                    Time = DateTime.Now
                });

            db.Servings.Add(
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
