using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using Repositories.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize(Roles = "Administrator")]
    public partial class WarningController : BaseController, IWarningController
    {
        private IWarningRepository warningRepository;
        private IPostRepository postRepository;
        private IUserRepository userRepository;

        public WarningController(){}

        public WarningController(IWarningRepository warningRepository, IPostRepository postRepository, IUserRepository userRepository)
        {
            this.warningRepository = warningRepository;
            this.postRepository = postRepository;
            this.userRepository = userRepository;
        }

        public virtual ActionResult Index(int id)
        {
            List<Warning> warnings = warningRepository.Get(m => m.UserId == id).ToList();
            return View(warnings);
        }

        public virtual ActionResult Warn(int postId)
        {
            Post post = postRepository.Get(m => m.Id == postId).Single();
            if (post == null)
                return RedirectToAction(MVC.Error.Index(-1, new MyException(-1)));
            User user = post.User;

            Warning warning = new Warning() { PostId = post.Id, UserId = user.Id, User = user };
            return View(warning);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Warn(Warning warning)
        {
            if (ModelState.IsValid)
            {
                int userId = warning.UserId;
                User user = userRepository.Get(m => m.Id == userId).Single();
                user.NumberOfWarnings++;

                userRepository.Update(user);
                warningRepository.Insert(warning);
                warningRepository.Save();


                return RedirectToAction(MVC.Message.Index(Forum.Controllers.MessageController.MailboxType.Inbox.ToString(),null));
            }
            int postId = warning.PostId;
            User u = postRepository.Get(m => m.Id == postId).Single().User;
            warning.User = u;
            return View(warning);
        }

        
    }
}