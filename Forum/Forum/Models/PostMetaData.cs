﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class PostMetaData
    {
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string PostContent { get; set; }

        [Required]
        public int ThreadId { get; set; }
    }

    [MetadataType(typeof(PostMetaData))]
    public partial class Post
    {
        
    }
}