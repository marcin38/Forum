using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class PostEditViewModel
    {
        [Required]
        public string PostContent { get; set; }

        [Required]
        public int PostId { get; set; }

    }
}