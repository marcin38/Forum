using Forum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum.ViewModels
{
    public class UserRegisterViewModelMetaData 
    {
        [System.Web.Mvc.Remote("IsUserNameAvailable", "User", ErrorMessage = "Ta nazwa użytkownika jest zajęta")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
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