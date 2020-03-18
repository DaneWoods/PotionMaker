using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PotionMaker.Models
{
    public class Recipe
    {
        private List<Ingredient> RIng = new List<Ingredient>();
        [Key]
        public int RecipeID { get; set; }
        public string RPotionName { get; set; }
        public string RPotionDesc { get; set; }
        public Ingredient RIng1 { get; set; }
        public Ingredient RIng2 { get; set; }
        public Ingredient RIng3 { get; set; }
    }
}
