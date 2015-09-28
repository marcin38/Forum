using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Forum.ViewModels;

namespace Forum.Controllers
{
    public class ThreadController : BaseController, IThreadController
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

        public ActionResult Index(int id, int? page)
        {
            ViewBag.UserId = GetUserId();
            IPagedList<Post> posts = 
                db.Posts
                .Where(m => m.ThreadId == id)
//                .OrderBy(m => m.CreationDate)
                .ToList()                
                .ToPagedList(page ?? 1, ItemsPerPage());
            return View(posts);
        }

        public ActionResult AddThread(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        [HttpPost]
        public ActionResult AddThread(ThreadAddThreadViewModel pt)
        {
            if (CheckIfUserIsAuthenticated())
            {
                if (ModelState.IsValid)
                {
                    Post post = new Post();
                    Thread thread = new Thread();
                    thread.AuthorId = GetUserId();
                    thread.CategoryId = pt.CategoryId;
                    thread.Title = pt.ThreadTitle;
                    db.Threads.Add(thread);
                    db.SaveChanges();

                    post.AuthorId = GetUserId();
                    post.CreationDate = DateTime.Now;
                    post.PostContent = pt.PostContent;
                    post.ThreadId = thread.Id;
                    db.Posts.Add(post);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Category", new { id = pt.CategoryId });
                }
                return View(pt);
            }
            else 
            {
                return RedirectToAction("Login", "User");
            }
        }

    }
}