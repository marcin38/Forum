using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class WarningController : BaseController, IWarningController
    {
        private IForumDBContext db;

        public WarningController()
        {
            db = new ForumDBContext();
        }

        public WarningController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Warn(int postId)
        {
            Post post = db.Posts.Where(m => m.Id == postId).Single();
            User user = post.User;

            Warning warning = new Warning() { PostId = post.Id, UserId = user.Id, User = user };
            return View(warning);
        }

        [HttpPost]
        public ActionResult Warn(Warning warning)
        {
            if (ModelState.IsValid)
            {
                int userId = warning.UserId;
                User user = db.Users.Where(m => m.Id == userId).Single();
                user.NumberOfWarnings++;

                db.SetModified(user);
                db.Warnings.Add(warning);
                db.SaveChanges();


                return RedirectToAction("Index", "Message", new { type = Forum.Controllers.MessageController.MailboxType.Inbox });
            }
            int postId = warning.PostId;
            User u = db.Posts.Where(m => m.Id == postId).Single().User;
            warning.User = u;
            return View(warning);
        }

        public ActionResult Index(int id)
        {
            List<Warning> warnings = db.Warnings.Where(m => m.UserId == id).ToList();
            return View(warnings);
        }

    }
}