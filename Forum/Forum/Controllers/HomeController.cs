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
    public class HomeController : BaseController, IHomeController
    {
        private IForumDBContext db;

        public enum SearchBy
        {
            User = 1,
            ThreadTitle = 2,
            PostContent = 3
        }

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

        public ActionResult Search(string searchBy, string search, int? page)
        {
            List<Post> posts = new List<Post>();

            if(searchBy ==  SearchBy.User.ToString())
            {
                posts = db.Posts.Where(m => search == String.Empty || m.User.Name == search).ToList();
            }
            else if (searchBy == SearchBy.ThreadTitle.ToString())
            {
                posts = db.Posts.Where(m => search == String.Empty || m.Thread.Title.ToLower().IndexOf(search.ToLower()) >= 0).ToList();
            }
            else if (searchBy == SearchBy.PostContent.ToString())
            {
                posts = db.Posts.Where(m => search == String.Empty || m.PostContent.ToLower().IndexOf(search.ToLower()) >= 0).ToList();

                //posts = db.Posts.ToList();
                //posts = posts.Where(m => m.PostContent.ToLower().IndexOf(search) >= 0);
            }

            posts.ToPagedList(page ?? 1, ItemsPerPage());

            return View(posts.ToPagedList(page ?? 1, ItemsPerPage()));
        }

    }
}