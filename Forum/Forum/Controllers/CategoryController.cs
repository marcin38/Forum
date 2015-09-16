using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{

    public class CategoryController : BaseController, ICategoryController
    {
        private IForumDBContext db;

        public CategoryController()
        {
            db = new ForumDBContext();
        }

        public CategoryController(IForumDBContext db)
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