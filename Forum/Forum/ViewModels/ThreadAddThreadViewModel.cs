using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class ThreadAddThreadViewModel
    {
        [Required]
        public string PostContent { get; set; }

        [Required]
        public string ThreadTitle { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}