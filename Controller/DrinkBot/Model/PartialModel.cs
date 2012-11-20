using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public partial class Recipe : IEnumerable<KeyValuePair<Ingredient, double>>
    {
        public override string ToString()
        {
            return Name;
        }

        public IEnumerable<Ingredient> Ingredients
        {
            get
            {
                return RecipeIngredients.Select(ri => ri.Ingredient1);
            }
        }

        public IEnumerator<KeyValuePair<Ingredient, double>> GetEnumerator()
        {

            return RecipeIngredients.Select(ri => new KeyValuePair<Ingredient, double>(ri.Ingredient1, (double)ri.Amount)).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public partial class User
    {
        public override string ToString()
        {
            return Name;
        }
    }

    public partial class Ingredient
    {
        public override string ToString()
        {
            return Name;
        }
    }
}
