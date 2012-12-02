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
            //SerialDrinkBot b = SerialDrinkBot.Local;

            ILiquidDispenser d = new DummyDispenser();

            d.Dispense("Gin",3.0);
            d.Dispense("Tonic Water", 1.5);

            
        }
    }
}
