using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{

    public class WarningMetaData
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        public string Reason { get; set; }
    }

    [MetadataType(typeof(WarningMetaData))]
    public partial class Warning
    {

    }
}