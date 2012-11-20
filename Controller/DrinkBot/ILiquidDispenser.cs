using DrinkBotLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib
{
    public interface ILiquidDispenser
    {
        bool CanDispense(string ingredient);

        void Dispense(string ingredient, double amount);
    }
}
