using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class RecipeIngredient
    {
        [Key]
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }

        [Key]
        public int IngredientID { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        [Required]
        public decimal Amount { get; set; }
        
        public bool Required { get; set; }

        public override string ToString()
        {
            return string.Format("{0} oz {1}", Amount, Ingredient.Name);
        }
    }
}
