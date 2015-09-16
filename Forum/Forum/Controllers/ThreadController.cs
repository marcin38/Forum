﻿using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Index(int id)
        {
            ViewBag.UserId = GetUserId();
            List<Post> posts = db.Posts.Where(m => m.ThreadId == id).ToList();
            return View(posts);
        }
    }
}