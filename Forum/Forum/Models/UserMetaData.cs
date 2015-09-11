using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Forum.Models
{
    public class UserMetaData
    {
        [Required]
        [StringLength(50, MinimumLength=3)]
        public string Name { get; set; }
        
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

        [Required]
        public string Password { get; set; }

        [Display(Name="Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}