using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PotionMaker.Models
{
    public class Ingredient
    {
        [Key]
        public int IngID { get; set; }
        public string IngPicture { get; set; }
        public string IngName { get; set; }
        public string IngDescription { get; set; }
        public int IngStock { get; set; }
    }
}
