using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class MerchantShopViewModel
    {
        [Required]
        public int IngredientID { get; set; }
        [Required(ErrorMessage = "Please input a number between 0-100")]
        [Range(0, 100)]
        public int AmountBought { get; set; }
        public List<Ingredient> IngList { get; set; }
    }
}
