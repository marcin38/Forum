using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    
    public class UserMetaData
    {
        [Display(Name = "Number of warnings")]
        public int NumberOfWarnings { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }
}
