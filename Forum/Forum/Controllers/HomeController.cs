using Domain.Models;
using Forum.Controllers.Interfaces;
using PagedList;
using Repositories.Repositories;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public partial class HomeController : BaseController, IHomeController
    {
        private ICategoryRepository categoryRepository;
        private IPostRepository postRepository;

        public enum SearchBy
        {
            User = 1,
            ThreadTitle = 2,
            PostContent = 3
        }

        public HomeController() { }

        public HomeController(IPostRepository postRepository, ICategoryRepository categoryRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
        }

        public virtual ActionResult Index()
        {
            try
            {
                List<CategoryStatistics> categories = categoryRepository.GetCategories().ToList();
                    
                return View(categories);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult About()
        {
            return View();
        }

        public virtual ActionResult Contact()
        {
            return View();
        }

        public virtual ActionResult Search(string searchBy, string search, int? page)
        {
            try
            {
                List<Post> posts = new List<Post>();

                if (searchBy == SearchBy.User.ToString())
                {
                    posts = postRepository.Get(m => search == String.Empty || m.User.Name == search).ToList();
                }
                else if (searchBy == SearchBy.ThreadTitle.ToString())
                {
                    posts = postRepository.Get(m => search == String.Empty || m.Thread.Title.ToLower().IndexOf(search.ToLower()) >= 0).ToList();
                }
                else if (searchBy == SearchBy.PostContent.ToString())
                {
                    posts = postRepository.Get(m => search == String.Empty || m.PostContent.ToLower().IndexOf(search.ToLower()) >= 0).ToList();
                }

                posts.ToPagedList(page ?? 1, ItemsPerPage());

                return View(posts.ToPagedList(page ?? 1, ItemsPerPage()));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}