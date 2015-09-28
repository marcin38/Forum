using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    //[RequireHttps]
    public class BaseController : Controller
    {
        protected int ItemsPerPage() 
        { 
            return 10;
        }

        public bool CheckIfUserIsAuthenticated()
        {
            HttpCookie cookie = Request.Cookies["f_user"];
            if (cookie == null)
                return false;
            else 
            {
                int id = int.Parse(cookie.Values["Id"]);
                string token = cookie.Values["Token"];
                if (!MvcApplication.tokenDictionary.ContainsKey(id) || !String.Equals(token, MvcApplication.tokenDictionary[id]))
                    return false;
                else
                {
                    return true;
                }
            }
            
        }

        public bool CheckIfUserIsAdministrator()
        {
            if (!this.CheckIfUserIsAuthenticated())
            {    
                return false;
            }
            else
            {
                int id = GetUserId();
                User user = (new ForumDBContext()).Users.SingleOrDefault(m => m.Id == id);
                return user.IsAdministrator;
            }
        }

        public string GetUserName()
        {
            HttpCookie cookie = Request.Cookies["f_user"];
            if (cookie == null)
                return String.Empty;
            else
                return cookie.Values["Name"];
        }

        public int GetUserId()
        {
            HttpCookie cookie = Request.Cookies["f_user"];
            if (cookie == null)
                return -1;
            else
                return int.Parse(cookie.Values["Id"]);
        }

    }
}