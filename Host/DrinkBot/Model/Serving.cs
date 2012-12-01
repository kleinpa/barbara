using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Serving
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public Recipe Recipe { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public decimal Scale { get; set; }
    }
}
