using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PotionMaker.Models
{
    public class Potion
    {
        public int PotionID { get; set; }
        public string PotionName { get; set; }
        public string PotionDescription { get; set; }
        public int PotionStock { get; set; }
    }
}
