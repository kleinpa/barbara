using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public User(string name)
        {
            this.Name = name;
        }

        public User()
        {
        }
    }
}
