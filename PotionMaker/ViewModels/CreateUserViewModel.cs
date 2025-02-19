﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PotionMaker.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
