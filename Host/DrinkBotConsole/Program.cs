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

            foreach (var user in rd.Users)
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
    }
}
