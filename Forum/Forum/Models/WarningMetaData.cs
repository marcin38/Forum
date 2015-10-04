using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    
    public class WarningMetaData
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string Reason { get; set; }
    }

    [MetadataType(typeof(WarningMetaData))]
    public partial class Warning
    {

    }
}