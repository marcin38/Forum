using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class ThreadAddThreadViewModel
    {
        [Required]
        public string PostContent { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string ThreadTitle { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}