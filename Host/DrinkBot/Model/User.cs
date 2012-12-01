using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public Recipe Favorite { get; set; }

        public virtual ICollection<Serving> Servings { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
