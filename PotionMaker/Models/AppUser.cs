using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PotionMaker.Models
{
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Please input a name for your account")]
        [StringLength(50, MinimumLength = 2)]
        public string Title { get; set; }
    }
}
