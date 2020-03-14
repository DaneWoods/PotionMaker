using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotionMaker.Models
{
    public class Ingredient
    {
        public int IngID { get; set; }
        public string IngName { get; set; }
        public string IngDescription { get; set; }
        public int IngStock { get; set; }
    }
}
