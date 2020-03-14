using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotionMaker.Models
{
    public class Recipe
    {
        private List<Ingredient> RIng = new List<Ingredient>();
        public int RecipeID { get; set; }
        public string RPotionName { get; set; }
        public List<Ingredient> RIngredients { get { return RIng; } }
    }
}
