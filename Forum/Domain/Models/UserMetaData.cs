using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    
    public class UserMetaData
    {
        [Display(Name = "Number of warnings")]
        public int NumberOfWarnings { get; set; }

        [DisplayFormat(DataFormatString="{0,d}")]
        public Nullable<System.DateTime> BirthDate { get; set; }
    }

    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }
}
