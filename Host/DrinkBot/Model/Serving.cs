using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Serving
    {
        public int ID { get; private set; }
        public Recipe Recipe { get; private set; }
        public User User { get; private set; }
        public DateTime Time { get; private set; }
        public decimal Scale { get; private set; }
    }
}
