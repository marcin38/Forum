using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

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

        public ActionResult Index(int id, int? page)
        {
            IPagedList<V_Threads> threads = db.V_Threads
                .Where(m => m.CategoryId == id)
                .OrderByDescending(m => m.WhenAddedLastPost)
                .ToList().ToPagedList(page ?? 1, ItemsPerPage());
            return View(threads);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();

                return RedirectToAction("AdministerCategories", "User");
            }

            return View(category);
        }

        public ActionResult Edit(int id)
        {
            Category category = db.Categories.SingleOrDefault(m => m.Id == id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.SetModified(category);
                db.SaveChanges();

                return RedirectToAction("AdministerCategories", "User");
            }

            return View(category);
        }

        public ActionResult Delete(int id)
        {
            Category category = db.Categories.SingleOrDefault(m => m.Id == id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.SingleOrDefault(m => m.Id == id);
            List<Post> posts = db.Posts.Where(m => m.Thread.CategoryId == id).ToList();
            List<Thread> threads = db.Threads.Where(m => m.CategoryId == id).ToList();

            foreach (Post p in posts)
                db.Posts.Remove(p);
            foreach (Thread t in threads)
                db.Threads.Remove(t);

            db.Categories.Remove(category);
            db.SaveChanges();

            return RedirectToAction("AdministerCategories", "User");
        }

    }
}