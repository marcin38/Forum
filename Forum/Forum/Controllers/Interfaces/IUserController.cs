using Forum.Models;
using Forum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IUserController
    {
        ActionResult Register();
        ActionResult Register(UserRegisterViewModel user, HttpPostedFileBase upload);
        ActionResult Login();
        ActionResult Login(AccountCredentials credentials);
        ActionResult LogOff();
        ActionResult ShowProfile(int? id);
        ActionResult EditProfile(int id);
        ActionResult EditProfile(UserEditProfileViewModel user, HttpPostedFileBase upload);
        ActionResult AdministerCategories();
    }
}
