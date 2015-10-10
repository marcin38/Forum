using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Forum.ViewModels
{
    public class MessageSendViewModel
    {
        [Required]
        public int To { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public SelectList Users { get; set; }
    }
}