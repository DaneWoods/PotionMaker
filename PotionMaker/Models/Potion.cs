using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PotionMaker.Models
{
    public class Potion
    {
        [Key]
        public int PotionID { get; set; }
        public bool CustomPotion { get; set; }
        public string PotionName { get; set; }
        public string PotionDescription { get; set; }
        public int PotionStock { get; set; }
    }
}
