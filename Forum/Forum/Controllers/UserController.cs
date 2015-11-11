using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using Forum.ViewModels;
using PagedList;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Controllers
{
    [Authorize]
    public partial class UserController : BaseController, IUserController
    {
        private IUserRepository userRepository;
        private IAvatarRepository avatarRepository;
        private ICategoryRepository categoryRepository;
        private IPostRepository postRepository;

        public UserController() { }

        public UserController(IUserRepository userRepository, IAvatarRepository avatarRepository, ICategoryRepository categoryRepository, IPostRepository postRepository)
        {
            this.userRepository = userRepository;
            this.avatarRepository = avatarRepository;
            this.categoryRepository = categoryRepository;
            this.postRepository = postRepository;
        }

        [Authorize(Roles = "Administrator")]
        public virtual ActionResult Index(string term, int? page)
        {
            try
            {
                IPagedList<User> users;
                if (String.IsNullOrEmpty(term))
                    users = userRepository.Get().ToList().ToPagedList(page ?? 1, ItemsPerPage());
                else
                    users = userRepository.Get(m => m.Name.ToLower().StartsWith(term.ToLower())).ToList().ToPagedList(page ?? 1, ItemsPerPage());
                if (Request.IsAjaxRequest())
                {
                    return PartialView(MVC.User.Views._Table, users);
                }

                return View(users);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [AllowAnonymous]
        public virtual ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Register(UserRegisterViewModel user, HttpPostedFileBase upload)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Avatar avatar = new Avatar();
                    if (upload != null && upload.ContentLength > 0)
                    {
                        using (var reader = new BinaryReader(upload.InputStream))
                        {
                            avatar.Image = reader.ReadBytes(upload.ContentLength);
                            avatar.ContentType = upload.ContentType;
                        }

                        avatarRepository.Insert(avatar);
                        avatarRepository.Save();
                    }

                    user.Hash = ComputeHash(user.Password, user.Name);
                    user.RegistrationDate = System.DateTime.Now;
                    if (avatar.Id > 0)
                        user.AvatarId = avatar.Id;

                    userRepository.Insert(user.CreateUser());
                    userRepository.Save();

                    return RedirectToAction(MVC.User.Login());
                }

                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [AllowAnonymous]
        public virtual ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(UserLoginViewModel credentials, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid && Membership.ValidateUser(credentials.Name, credentials.Password))
                {
                    User user = userRepository.Get(m => m.Name == credentials.Name).Single();
                    SaveCookie(user);

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password is incorrect");
                }

                return View(credentials);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult LogOff()
        {
            DeleteCookie();
            return RedirectToAction(MVC.Home.Index());
        }

        public virtual ActionResult ShowProfile(int? id)
        {
            try
            {
                if (id == null && User != null)
                    id = User.Id;
                if (id == null)
                    return RedirectToAction(MVC.Error.Index(-1, new MyException(-1)));

                User user = userRepository.Get(u => u.Id == id, null, "Avatar").FirstOrDefault();

                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult RenderPhoto(int id)
        {
            try
            {
                Avatar avatar = avatarRepository.Get(m => m.Id == id).FirstOrDefault();

                return File(avatar.Image, avatar.ContentType);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult EditProfile(int id)
        {
            try
            {
                User user = GetMyUserById();
                ViewBag.Name = user.Name;

                UserEditProfileViewModel u = new UserEditProfileViewModel(user);
                return View(u);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult EditProfile(UserEditProfileViewModel user, HttpPostedFileBase upload)
        {
            try
            {
                User u = GetMyUserById();

                if (ModelState.IsValid)
                {

                    u.Location = user.Location;

                    Avatar avatar = new Avatar();
                    if (upload != null && upload.ContentLength > 0)
                    {
                        using (var reader = new BinaryReader(upload.InputStream))
                        {
                            avatar.Image = reader.ReadBytes(upload.ContentLength);
                            avatar.ContentType = upload.ContentType;
                        }

                        avatarRepository.Insert(avatar);
                        avatarRepository.Save();
                    }


                    if (avatar.Id > 0)
                        u.AvatarId = avatar.Id;

                    userRepository.Update(u);
                    userRepository.Save();

                    return RedirectToAction(MVC.User.ShowProfile(u.Id));
                }
                return View(new UserEditProfileViewModel(u));
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [Authorize(Roles = "Administrator")]
        public virtual ActionResult AdministerCategories()
        {
            try
            {
                List<Category> categories = categoryRepository.Get().ToList();
                return View(categories);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize(Roles = "Administrator")]
        public virtual ActionResult Delete(int id)
        {
            try
            {
                User user = GetUserById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            try
            {
                User user = GetUserById(id);
                if (ModelState.IsValid)
                {

                    user.Name = "Removed" + id;
                    user.Email = "";
                    user.Hash = new byte[1] { 0x01 };
                    user.IsAdministrator = false;
                    user.Location = "";
                    user.RemovalDate = DateTime.Now;

                    userRepository.Update(user);
                    userRepository.Save();

                    return RedirectToAction(MVC.User.Index());
                }

                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize(Roles = "Administrator")]
        public virtual ActionResult Ban(int id)
        {
            try
            {
                User user = GetUserById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ActionName("Ban")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult BanConfirmed(int id)
        {
            try
            {
                User user = GetUserById(id);

                if (ModelState.IsValid)
                {
                    user.IsBanned = true;

                    userRepository.Update(user);
                    userRepository.Save();

                    return RedirectToAction(MVC.User.Index());
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Authorize(Roles = "Administrator")]
        public virtual ActionResult Unban(int id)
        {
            try
            {
                User user = GetUserById(id);
                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpPost]
        [ActionName("Unban")]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult UnbanConfirmed(int id)
        {
            try
            {
                User user = GetUserById(id);
                if (ModelState.IsValid)
                {
                    user.IsBanned = false;

                    userRepository.Update(user);
                    userRepository.Save();

                    return RedirectToAction(MVC.User.Index());
                }
                return View(user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        public virtual ActionResult MyPosts(int? page)
        {
            try
            {
                IPagedList<Post> posts = postRepository.Get(m => m.AuthorId == User.Id).ToList().ToPagedList(page ?? 1, ItemsPerPage());
                return View(posts);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [AllowAnonymous]
        public virtual JsonResult IsUserNameAvailable(string Name)
        {
            bool result = false;
            try
            {
                User user = userRepository.Get(m => m.Name == Name.ToLower()).Single();
                result = false;
            }
            catch
            {
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetNames(string term)
        {
            List<User> users = userRepository.Get(m => m.Name.ToLower().StartsWith(term.ToLower())).ToList();
            List<String> names = users.Select(m => m.Name).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        private byte[] ComputeHash(string data, string salt)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(String.Format("{0}{1}", data, salt)));
            return hash;
        }

        private void SaveCookie(User user)
        {
            HttpCookie cookie = new HttpCookie("f_user");
            cookie.Values["Name"] = user.Name;
            cookie.Values["Id"] = user.Id.ToString();
            cookie.Values["Token"] = MvcApplication.tokenDictionary[user.Id] = GenerateToken(100);
            HttpContext.Response.Cookies.Add(cookie);
        }

        private void DeleteCookie()
        {
            if (Request.Cookies["f_user"] != null)
            {
                HttpCookie cookie = new HttpCookie("f_user");
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
        }

        private string GenerateToken(int tokenLength)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] buffer = new char[tokenLength];

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < tokenLength; i++)
            {
                buffer[i] = chars[random.Next(chars.Length)];
            }

            return new string(buffer);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(MVC.Home.Index());
            }
        }

        private User GetMyUserById()
        {
            if (User == null)
                throw new MyException(-1);
            User user = GetUserById(User.Id);

            return user;
        }

        private User GetUserById(int id)
        {
            User user = userRepository.Get(m => m.Id == id).FirstOrDefault();
            if (user == null)
                throw new MyException(-1);

            return user;
        }
    }
}