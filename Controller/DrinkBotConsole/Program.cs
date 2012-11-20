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
            SerialDrinkBot b = SerialDrinkBot.Local;
            
            using (var db = new DrinkBotEntities())
            {
                b.Dispense(db.Recipes.Single(r => r.Name == "Gin and Tonic"));
            }

            
        }
    }
}
