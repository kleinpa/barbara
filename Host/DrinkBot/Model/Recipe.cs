using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Recipe
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public override string ToString()
        {
            return Name;
        }

        [Url]
        public string ImageUrl { get; set; }

        [NotMapped]
        public decimal Volume
        {
            get
            {
                return Ingredients.Sum(i => i.Amount);
            }
        }

        [NotMapped]
        public decimal AlcoholByVolume
        {
            get
            {
                return Ingredients.Sum(i => i.Ingredient.AlcoholByVolume * i.Amount)/Volume;
            }
        }
    }
}
