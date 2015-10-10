using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}