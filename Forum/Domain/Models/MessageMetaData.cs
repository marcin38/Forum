using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Models
{
    public class MessageMetaData
    {
        [StringLength(100, MinimumLength = 3)]
        [Required]
        [AllowHtml]
        public string Subject { get; set; }

        [Required]
        [AllowHtml]
        public string Body { get; set; }
    }

    [MetadataType(typeof(MessageMetaData))]
    public partial class Message
    {

    }
}