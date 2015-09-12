using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class UserController : Controller
    {
        private IForumDBContext db = new ForumDBContext();

        public UserController(IForumDBContext db)
        {
            this.db = db;
        }

        // GET: User
        public ActionResult Index()
        {
            return View(db.Users.OrderBy(m => m.Name).ToList());
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                user.Hash = System.Text.Encoding.UTF8.GetBytes(user.Password);
                user.RegistrationDate = System.DateTime.Now;
                db.SaveChanges();
            }

            

            return View(user);
        }
    }
}