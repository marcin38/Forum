using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class ThreadController : Controller
    {
        private IForumDBContext db;

        public ThreadController()
        {
            db = new ForumDBContext();
        }

        public ThreadController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index(int id)
        {
            List<V_Threads> threads = db.V_Threads.Where(m => m.CategoryId == id).ToList();
            return View(threads);
        }
    }
}