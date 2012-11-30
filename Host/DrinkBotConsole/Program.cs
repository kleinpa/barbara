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
            using (Context cx = new Context())
            {
                cx.Database.CreateIfNotExists();

                foreach (var user in cx.Users)
                {
                    System.Console.WriteLine("{0}({1})", user.Name, user.ID);
                }

                User u = new User { Name = "Peter"};
                cx.Users.Add(u);
                cx.SaveChanges();
                
            }
            System.Console.WriteLine("Done");
            System.Console.ReadKey(false);


            
        }
    }
}
