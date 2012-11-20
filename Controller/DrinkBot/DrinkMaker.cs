using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib
{
    public abstract class DrinkMaker
    {
        //public Dictionary<string, byte> Ingredients { get; set; }

        public abstract void Dispense(IEnumerable<KeyValuePair<Ingredient, double>> recipe);
    }
}
