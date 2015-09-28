using Forum.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.ViewModels
{

    public class UserEditProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public int? AvatarId {get; set;}

        public UserEditProfileViewModel() {}
        public UserEditProfileViewModel(User u)
        {
            Id = u.Id;
            Name = u.Name;
            Email = u.Email;
            Location = u.Location;
            AvatarId = u.AvatarId;
        }
    }

}