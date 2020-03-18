using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionCreationViewModel
    {
        [Required(ErrorMessage = "Please input a name for your potion")]
        [StringLength(50, MinimumLength = 2)]
        public string PotionName { get; set; }
        public int RecipeID { get; set; }
        [Required(ErrorMessage = "Please input a name for your potion")]
        [StringLength(50, MinimumLength = 2)]
        public string PotionDesc { get; set; }
        [Required]
        public int RIng1ID { get; set; }
        [Required]
        public int RIng2ID { get; set; }
        [Required]
        public int RIng3ID { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Recipe> Recipes { get; set; }
        public bool outOfStock { get; set; }
        public bool Error { get; set; }
    }
}
