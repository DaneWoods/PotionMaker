using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class SearchViewModel
    {
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Potion> Potions { get; set; }
        public int potionInID { get; set; }
        public int potionOutID { get; set; }
        public int recipeInID { get; set; }
        public int recipeOutID { get; set; }
        public int ingredientInID { get; set; }
        public int ingredientOutID { get; set; }
    }
}
