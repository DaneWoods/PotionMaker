using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionRecipeCreationViewModel
    {
        [Required]
        public int RecipeID { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }
        public bool outOfStock { get; set; }
    }
}
