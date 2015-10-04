using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    

    public class CategoryMetaData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }
}