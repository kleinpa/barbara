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
            
            db.SaveChanges();

            Ingredient gin = new Ingredient { Name = "Gin", AlcoholByVolume = 40 };
            gin = db.Ingredients.Add(gin);

            Ingredient tonic = new Ingredient { Name = "Tonic", AlcoholByVolume = 0 };
            tonic = db.Ingredients.Add(tonic);

            Recipe gnt = new Recipe { Name = "Gin and Tonic", ImageUrl="http://gentlemansjournal.files.wordpress.com/2012/01/gin-and-tonic-fb-1.jpg"};
            gnt = db.Recipes.Add(gnt);

            db.SaveChanges();

            db.RecipeIngredients.Add(new RecipeIngredient { Ingredient = tonic, Recipe = gnt, Amount = 3 });
            db.RecipeIngredients.Add(new RecipeIngredient { Ingredient = gin, Recipe = gnt, Amount = 1.5M });

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
