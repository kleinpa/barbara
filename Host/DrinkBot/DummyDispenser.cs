using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrinkBotLib
{
    public class DummyDispenser : ILiquidDispenser
    {
        public DummyDispenser(string[] ingredients)
        {
            this.ingredients = ingredients;
            this.allIngredients = false;
        }

        public DummyDispenser()
        {
            allIngredients = true;
        }

        private IEnumerable<string> ingredients;
        private bool allIngredients;

        public bool CanDispense(string ingredient)
        {
            return allIngredients || ingredients.Contains(ingredient);
        }

        public void Dispense(string ingredient, double amount)
        {
            MessageBox.Show(string.Format("Dispensing {1} ounces of {0}", ingredient, amount));
        }

        public DummyDispenser Warn(string warning = "")
        {
            MessageBox.Show(string.Format("{0} Using Dummy Dispenser",warning));
            return this;
        }
    }
}
