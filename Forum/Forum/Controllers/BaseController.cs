using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class BaseController : Controller
    {
        

        protected bool CheckIfUserIsAuthenticated()
        {
            HttpCookie cookie = Request.Cookies["f_user"];
            string s = cookie.Values["Name"];
            if (cookie == null)
                return false;
            else
                return true;
            
        }

        protected int GetUserId()
        {
            return 1002;
        }
    }
}