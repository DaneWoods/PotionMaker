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
        [Required(ErrorMessage = "Please input a title for your story")]
        [StringLength(50, MinimumLength = 2)]
        public string PotionName { get; set; }
        public string PotionDescription { get; set; }
        public Ingredient PIng1 { get; set; }
        public Ingredient PIng2 { get; set; }
        public Ingredient PIng3 { get; set; }
        public int PotionStock { get; set; }
    }
}
