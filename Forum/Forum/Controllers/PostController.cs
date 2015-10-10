﻿using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
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
        
        public PostController(){}

        public PostController(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public virtual ActionResult AddPost(int threadId)
        {
            ViewBag.ThreadId = threadId;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult AddPost(Post post)
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

        public virtual ActionResult EditPost(int id)
        {
            try
            {
                Post post = GetMyPostById(id);
                ViewBag.ThreadId = post.ThreadId;

                return View(MVC.Post.Views.AddPost, post);
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditPost(Post post)
        {
            try
            {
                Post p = GetMyPostById(post.Id);
                p.PostContent = post.PostContent;

                if (ModelState.IsValid)
                {
                    postRepository.Update(p);
                    postRepository.Save();

                    return RedirectToAction(MVC.Thread.Index(p.ThreadId, null));
                }

                return View(MVC.Post.AddPost(post));
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult ShowPost(int id)
        {
            Post post = GetPostById(id);
            return View(post);
        }

        private Post GetMyPostById(int id)
        {
            Post post = GetPostById(id);
            

            if (User == null || User.Id != post.AuthorId )
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