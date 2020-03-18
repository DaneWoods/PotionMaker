using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionStockViewModel
    {
        [Required]
        public int PotionID { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Potion> Potions { get; set; }
    }
}
