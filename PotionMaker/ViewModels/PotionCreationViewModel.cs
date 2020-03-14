using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionCreationViewModel
    {
        public string RIng1 { get; set; }
        public string RIng2 { get; set; }
        public string RIng3 { get; set; }
        public List<Ingredient> IngList { get; set; }
    }
}
