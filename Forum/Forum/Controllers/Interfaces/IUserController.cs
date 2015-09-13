using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IUserController
    {
        ActionResult RegisterUser();
        ActionResult RegisterUser(User user);
        ActionResult Login();
        ActionResult Login(AccountCredentials credentials);
    }
}
