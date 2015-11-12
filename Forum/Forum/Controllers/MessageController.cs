using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using Forum.ViewModels;
using PagedList;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize]
    public partial class MessageController : BaseController, IMessageController
    {
        private IMessageRepository messageRepository;
        private IUserRepository userRepository;

        public enum MailboxType
        {
            Inbox = 1,
            Sent = 2
        }

        public MessageController() { }

        public MessageController(IMessageRepository messageRepository, IUserRepository userRepository)
        {
            this.messageRepository = messageRepository;
            this.userRepository = userRepository;
        }

        public virtual ActionResult Index(string type, string sortOrder,int? page)
        {
            try
            {
                IPagedList<Message> messages = null;
                Func<IQueryable<Message>, IOrderedQueryable<Message>> orderBy = null;
                ViewBag.Sort = String.IsNullOrEmpty(sortOrder) ? "Sent_date_desc" : sortOrder;
                switch(sortOrder)
                {
                    case "Sender_desc":
                        orderBy = x => x.OrderByDescending(y => y.User.Name);
                        break;
                    case "Sender_asc":
                        orderBy = x => x.OrderBy(y => y.User.Name);
                        break;
                    case "Recipient_desc":
                        orderBy = x => x.OrderByDescending(y => y.User1.Name);
                        break;
                    case "Recipient_asc":
                        orderBy = x => x.OrderBy(y => y.User1.Name);
                        break;
                    case "Subject_desc":
                        orderBy = x => x.OrderByDescending(y => y.Subject);
                        break;
                    case "Subject_asc":
                        orderBy = x => x.OrderBy(y => y.Subject);
                        break;
                    case "Sent_date_desc":
                        orderBy = x => x.OrderByDescending(y => y.SentDate);
                        break;
                    case "Sent_date_asc":
                        orderBy = x => x.OrderBy(y => y.SentDate);
                        break;
                    default: 
                        orderBy = x => x.OrderByDescending(y => y.SentDate);
                        break;
                }
                
                if (type.Equals(MailboxType.Inbox.ToString()))
                {
                    int to = User.Id;
                    messages = messageRepository.Get(m => m.To == to && m.DeletedByRecipient == false, orderBy).ToList().ToPagedList(page ?? 1, ItemsPerPage());
                }
                else if (type.Equals(MailboxType.Sent.ToString()))
                {
                    int from = User.Id;
                    messages = messageRepository.Get(m => m.From == from && m.DeletedBySender == false, orderBy).ToList().ToPagedList(page ?? 1, ItemsPerPage());
                }
                ViewBag.Type = type;
                return View(messages);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult Send()
        {
            try
            {
                MessageSendViewModel message = new MessageSendViewModel();
                message.Users = new SelectList(userRepository.Get(m => m.RemovalDate == null), "Id", "Name");
                return View(message);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Send(Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    message.DeletedByRecipient = false;
                    message.DeletedBySender = false;
                    message.IsRead = false;
                    message.SentDate = DateTime.Now;
                    message.From = User.Id;
                    if (message.To == 0)
                    {
                        List<User> moderators = userRepository.Get(m => m.IsAdministrator == true).ToList();
                        foreach (User m in moderators)
                        {
                            message.To = m.Id;
                            messageRepository.Insert(message);
                        }
                    }
                    else
                    {
                        messageRepository.Insert(message);
                    }

                    messageRepository.Save();

                    return RedirectToAction(MVC.Message.Index(MailboxType.Sent.ToString(), null, null));
                }

                return View(message);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual EmptyResult Read(int id)
        {
            try
            {
                Message message = GetMyMessageById(id);

                int userId = User.Id;
                bool markAsRead = userId.Equals(message.To);

                if (markAsRead && !message.IsRead)
                {
                    message.IsRead = true;

                    messageRepository.Update(message);
                    messageRepository.Save();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return new EmptyResult();
        }

        public virtual ActionResult Delete(int id)
        {
            try
            {
                Message message = GetMyMessageById(id);
                return View(message);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Message message = GetMyMessageById(id);

                if (ModelState.IsValid)
                {

                    if (message.From == User.Id)
                    {
                        message.DeletedBySender = true;
                    }
                    else
                    {
                        message.DeletedByRecipient = true;
                    }
                    messageRepository.Update(message);
                    messageRepository.Save();

                    if (message.From == User.Id)
                    {
                        return RedirectToAction(MVC.Message.Index(MailboxType.Inbox.ToString(), null, null));
                    }
                    else
                    {
                        return RedirectToAction(MVC.Message.Index(MailboxType.Sent.ToString(), null, null));
                    }
                }

                return View(message);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private Message GetMyMessageById(int id)
        {
            Message message = GetMessageById(id);

            if (User == null || (User.Id != message.From && User.Id != message.To))
            {
                throw new HttpException(403, "Unauthorized access. The request requires user authentication. If the request already included Authorization credentials, then the 401 response indicates that authorization has been refused for those credentials.");

            }

            return message;
        }

        private Message GetMessageById(int id)
        {
            Message message = messageRepository.Get(m => m.Id == id && (m.DeletedBySender == false || m.DeletedByRecipient == false)).FirstOrDefault();
            if (message == null)
            {
                throw new MyException(-1);
            }
            return message;
        }

    }
}