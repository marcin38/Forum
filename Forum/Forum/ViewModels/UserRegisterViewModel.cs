using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Forum.ViewModels
{
    public class UserRegisterViewModelMetaData 
    {
        [System.Web.Mvc.Remote("IsUserNameAvailable", "User", ErrorMessage = "This name is taken")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^(?!Removed)\w+$", ErrorMessage = "User name must be built from letters, numbers and underscore. It cannot start with Removed.")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }
    }

    [MetadataType(typeof(UserRegisterViewModelMetaData))]
    public partial class UserRegisterViewModel : User
    {

        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string OldPassword { get; set; }

        public User CreateUser()
        {
            User user = new User();
            user.AvatarId = this.AvatarId;
            user.Email = this.Email;
            user.Hash = this.Hash;
            user.Id = this.Id;
            user.Location = this.Location;
            user.Name = this.Name;
            user.RegistrationDate = this.RegistrationDate;

            return user;
        }
    }

    

}