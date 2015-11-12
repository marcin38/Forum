using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using Forum.ViewModels;
using Repositories.Repositories.Interfaces;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize]
    public partial class PostController : BaseController, IPostController
    {
        private IPostRepository postRepository;

        public PostController() { }

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Add(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.AuthorId = User.Id;
                    post.CreationDate = DateTime.Now;

                    postRepository.Insert(post);
                    postRepository.Save();

                    return RedirectToAction(MVC.Thread.Index(post.ThreadId, null));
                }

                return View(post);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(PostEditViewModel post)
        {
            try
            {
                Post p = GetMyPostById(post.PostId);
                p.PostContent = post.PostContent;

                if (ModelState.IsValid)
                {
                    postRepository.Update(p);
                    postRepository.Save();

                    return RedirectToAction(MVC.Thread.Index(p.ThreadId, null));
                }

                return View(MVC.Post.Edit(post));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult ShowPost(int id)
        {
            try
            {
                Post post = GetPostById(id);
                return View(post);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private Post GetMyPostById(int id)
        {
            Post post = GetPostById(id);


            if (User == null || User.Id != post.AuthorId)
            {
                throw new HttpException(403, "Unauthorized access. The request requires user authentication. If the request already included Authorization credentials, then the 401 response indicates that authorization has been refused for those credentials.");

            }

            return post;
        }

        private Post GetPostById(int id)
        {
            Post post = postRepository.Get(m => m.Id == id).FirstOrDefault();
            if (post == null)
                throw new MyException(-1);
            return post;
        }

    }
}