﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PotionMaker.Models;

namespace PotionMaker.ViewModels
{
    public class PotionCreationViewModel
    {
        public int RIng1ID { get; set; }
        public int RIng2ID { get; set; }
        public int RIng3ID { get; set; }
        public List<Ingredient> IngList { get; set; }
    }
}
