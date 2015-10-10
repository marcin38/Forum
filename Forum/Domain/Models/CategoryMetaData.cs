using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{


    public class CategoryMetaData
    {
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }
    }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category
    {

    }
}