using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionStockViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Potion> Potions { get; set; }
    }
}
