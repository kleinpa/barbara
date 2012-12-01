using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Ingredient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<RecipeIngredient> Recipes { get; set; }

        [Required]
        public decimal AlcoholByVolume { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
