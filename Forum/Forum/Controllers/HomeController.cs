using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeController : BaseController, IHomeController
    {
        private IForumDBContext db;

        public HomeController()
        {
            db = new ForumDBContext();
        }

        public HomeController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            List<V_Categories> categories = db.V_Categories.ToList();
            return View(categories);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}