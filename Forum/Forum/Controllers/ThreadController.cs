using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.ViewModels;
using PagedList;
using Repositories.Repositories.Interfaces;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize]
    public partial class ThreadController : BaseController, IThreadController
    {
        private IThreadRepository threadRepository;
        private IPostRepository postRepository;

        public ThreadController() { }

        public ThreadController(IThreadRepository threadRepository, IPostRepository postRepository)
        {
            this.threadRepository = threadRepository;
            this.postRepository = postRepository;
        }

        [AllowAnonymous]
        public virtual ActionResult Index(int id, int? page)
        {
            try
            {
                IPagedList<Post> posts = postRepository.Get(m => m.ThreadId == id)
                    .ToList()
                    .ToPagedList(page ?? 1, ItemsPerPage());

                return View(posts);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult AddThread(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddThread(ThreadAddThreadViewModel pt)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Post post = new Post();
                    Thread thread = new Thread();
                    thread.AuthorId = User.Id;
                    thread.CategoryId = pt.CategoryId;
                    thread.Title = pt.ThreadTitle;

                    threadRepository.Insert(thread);
                    threadRepository.Save();

                    post.AuthorId = User.Id;
                    post.CreationDate = DateTime.Now;
                    post.PostContent = pt.PostContent;
                    post.ThreadId = thread.Id;

                    postRepository.Insert(post);
                    postRepository.Save();

                    return RedirectToAction(MVC.Category.Index(pt.CategoryId, null));
                }
                return View(pt);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

    }
}