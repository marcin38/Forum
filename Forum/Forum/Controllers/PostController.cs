using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class PostController : BaseController, IPostController
    {
        private IForumDBContext db;
        
        public PostController()
        {
            db = new ForumDBContext();
        }

        public PostController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPost(int threadId)
        {
            ViewBag.ThreadId = threadId;

            if (CheckIfUserIsAuthenticated())
            {
//                return View();
            }
            else 
            {
//                return "Nie możesz dodawać postów";
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(Post post)
        {

            if (CheckIfUserIsAuthenticated())
            {

                if (ModelState.IsValid)
                {
                    post.AuthorId = GetUserId();
                    post.CreationDate = DateTime.Now;
                    db.Posts.Add(post);
                    db.SaveChanges();

/*                    Thread thread = db.Threads.SingleOrDefault(m => m.Id == post.ThreadId);
                    db.SetModified(thread);
                    db.SaveChanges();*/
                    return RedirectToAction("Index", "Thread", new { id = post.ThreadId });
                }
                else
                {
                    return View(post);
                }

            }
            else 
            {
                return RedirectToAction("Login", "User");
            }

        }

        public ActionResult EditPost(int id)
        {
            Post post = db.Posts.Single(p => p.Id == id);
            ViewBag.ThreadId = post.ThreadId;
            return View("AddPost",post);
        }

        [HttpPost]
        public ActionResult EditPost(Post post)
        {
            Post p = db.Posts.Single(m => m.Id == post.Id);
            p.PostContent = post.PostContent;

            if (CheckIfUserIsAuthenticated())
            {
                if (ModelState.IsValid)
                {
                    db.SetModified(p);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Thread", new { id = p.ThreadId });
                }
                else
                {
                    return View("AddPost", post);
                }
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult ShowPost(int id)
        {
            Post post = db.Posts.Where(m => m.Id == id).Single();
            return View(post);
        }

    }
}