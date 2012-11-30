﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkBotLib.Model
{
    public class Ingredient
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public ICollection<Recipe> Recipes { get; private set; }
    }
}
