using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class MerchantShopViewModel
    {
        public int IngredientID { get; set; }
        public int AmountBought { get; set; }
        public List<Ingredient> IngList { get; set; }
    }
}
