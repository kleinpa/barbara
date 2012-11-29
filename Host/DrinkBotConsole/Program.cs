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
            Context cx = new Context();
            
            cx.Users.Add(new User{Name = "Peter", ID=1});
            cx.SaveChanges();
            


            
        }
    }
}
