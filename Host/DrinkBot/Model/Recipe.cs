using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Recipe
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public ICollection<Ingredient> Ingredients { get; private set; }
    }
}
