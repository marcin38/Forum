using Forum.Controllers.Interfaces;
using Forum.Models;
using Forum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Forum.Controllers
{
    public class MessageController : BaseController, IMessageController
    {
        private IForumDBContext db;

        public enum MailboxType
        {
            Inbox = 1,
            Sent = 2
        }

        public MessageController()
        {
            db = new ForumDBContext();
        }

        public MessageController(IForumDBContext db)
        {
            this.db = db;
        }

        // GET: Message
        public ActionResult Index(string type, int? page)
        {
            IPagedList<Message> messages = null;
            if (type.Equals(MailboxType.Inbox.ToString()))
            {
                int to = GetUserId();
                messages = db.Messages.Where(m => m.To == to && m.DeletedBySender == false).ToList().ToPagedList(page ?? 1, ItemsPerPage());
            }
            else if (type.Equals(MailboxType.Sent.ToString()))
            {
                int from = GetUserId();
                messages = db.Messages.Where(m => m.From == from && m.DeletedBySender == false).ToList().ToPagedList(page ?? 1, ItemsPerPage());
            }
            ViewBag.Type = type;
            return View(messages);

        }

        public ActionResult Send()
        {
            MessageSendViewModel message = new MessageSendViewModel();
            message.Users = new SelectList(db.Users.Where(m => m.RemovalDate == null), "Id", "Name");
            return View(message);
        }

        [HttpPost]
        public ActionResult Send(Message message)
        {
            if (ModelState.IsValid)
            {
                message.DeletedByRecipient = false;
                message.DeletedBySender = false;
                message.IsRead = false;
                message.SentDate = DateTime.Now;
                message.From = GetUserId();
                if (message.To == 0)
                {
                    List<User> moderators = db.Users.Where(m => m.IsAdministrator == true).ToList();
                    foreach (User m in moderators)
                    {
                        message.To = m.Id;
                        db.Messages.Add(message);
                    }
                }
                else
                {
                    db.Messages.Add(message);
                }

                db.SaveChanges();

                return RedirectToAction("Index", new { type = MailboxType.Sent });
            }

            return View(message);
        }

        public ActionResult Show(int id)
        {
            Message message = db.Messages.Where(m => m.Id == id && m.DeletedBySender == false).SingleOrDefault();
            int userId = GetUserId();
            bool markAsRead = userId.Equals(message.To);

            if (markAsRead && !message.IsRead)
            {
                message.IsRead = true;
                db.SetModified(message);
                db.SaveChanges();
            }
            return PartialView("_Body", message);
        }

        public ActionResult Delete(int id)
        {
            Message message = db.Messages.Where(m => m.Id == id).SingleOrDefault();
            return View(message);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Where(m => m.Id == id).SingleOrDefault();
            message.DeletedBySender = true;
            db.SetModified(message);
            db.SaveChanges();

            return RedirectToAction("Index", new { type = Forum.Controllers.MessageController.MailboxType.Inbox });
        }

    }
}