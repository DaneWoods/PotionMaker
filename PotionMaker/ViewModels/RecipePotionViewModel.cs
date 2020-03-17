using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class RecipePotionViewModel
    {
        public int RecipeID { get; set; }
        public List<Recipe> Recipes { get; set; }
    }
}
