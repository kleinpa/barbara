using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Context : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Serving> Servings { get; set; }
        public DbSet<User> Users { get; set; }

        public Context() : base(@"Data Source=|DataDirectory|\Database.sdf")
        {
        }
    }
}
