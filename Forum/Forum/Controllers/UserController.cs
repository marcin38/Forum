using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;
using System.Security.Cryptography;
using System.Text;
using Forum.Controllers.Interfaces;
using System.IO;
using System.Data.Entity;
using PagedList;
using Forum.ViewModels;

namespace Forum.Controllers
{
    public class UserController : BaseController, IUserController
    {
        private IForumDBContext db;

        public UserController()
        {
            db = new ForumDBContext();
        }

        public UserController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index(int? page)
        {
            IPagedList<User> users = db.Users.ToList().ToPagedList(page ?? 1, ItemsPerPage());
            return View(users);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegisterViewModel user, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                Avatar avatar = new Avatar();
                if (upload != null && upload.ContentLength > 0)
                {
                    using(var reader = new BinaryReader(upload.InputStream))
                    {
                        avatar.Image = reader.ReadBytes(upload.ContentLength);
                        avatar.ContentType = upload.ContentType;
                    }
                    db.Avatars.Add(avatar);
                    db.SaveChanges();
                }

                user.Hash = ComputeHash(user.Password, user.Name);
                user.RegistrationDate = System.DateTime.Now;
                if (avatar.Id > 0)
                    user.AvatarId = avatar.Id;
                
                db.Users.Add(user.CreateUser());
                db.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountCredentials credentials)
        {
            byte[] password = ComputeHash(credentials.Password, credentials.Name);

            if (ModelState.IsValid)
            {
                List<User> users = db.Users
                    .Where(u => u.Name == credentials.Name).ToList();

                if (users.Count == 0)
                {
                    ModelState.AddModelError("", "There is no user with that name");
                }
                else if (!password.SequenceEqual(users.ElementAt(0).Hash))
                {
                    ModelState.AddModelError("", "Password is wrong");
                }
                else
                {
                    User user = users.ElementAt(0);
                    //user.Password = credentials.Password;
                    SaveCookie(user);
                    //var u = new ApplicationUser() { UserName = user.Name};
                    //var result = await UserManager.CreateAsync(u, credentials.Password);
                    //await SignIn(u, false);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(credentials);
        }

        public ActionResult LogOff()
        {
            DeleteCookie();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ShowProfile(int? id)
        {
            if (id == null)
                id = GetUserId();
            List<User> users = db.Users.Include(m => m.Avatar).Where(u => u.Id == id).ToList();

            if (users.Count > 0)
            {
                return View(users.ElementAt(0));
            }

            return View();
        }

        public ActionResult RenderPhoto(int id)
        {
            Avatar avatar = db.Avatars.Where(m => m.Id == id).SingleOrDefault();
            return File(avatar.Image, avatar.ContentType);
        }

        public ActionResult EditProfile(int id)
        {
            ViewBag.Name = GetUserName();
            User user = db.Users.Where(m => m.Id == id).SingleOrDefault();
            UserEditProfileViewModel u = new UserEditProfileViewModel(user);
            return View(u);
        }

        [HttpPost]
        public ActionResult EditProfile(UserEditProfileViewModel user, HttpPostedFileBase upload)
        {
            User u = db.Users.Where(m => m.Id == user.Id).SingleOrDefault();
            //byte[] password = ComputeHash(user.OldPassword, user.Name);

            
            if (ModelState.IsValid)
            {
                //if (!password.SequenceEqual(u.Hash))
                //{
                //    ModelState.AddModelError("", "Old password is wrong");
                //}

                //if (user.Password != null)
                //{
                //    u.Hash = ComputeHash(user.Password, user.Name);
                //}

                u.Location = user.Location;

                Avatar avatar = new Avatar();
                if (upload != null && upload.ContentLength > 0)
                {
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        avatar.Image = reader.ReadBytes(upload.ContentLength);
                        avatar.ContentType = upload.ContentType;
                    }
                    db.Avatars.Add(avatar);
                    db.SaveChanges();
                }


                if (avatar.Id > 0)
                    u.AvatarId = avatar.Id;

                db.SetModified(u);
                db.SaveChanges();

                return RedirectToAction("ShowProfile", new {id = u.Id});
            }
            return View(new UserEditProfileViewModel(u));
        }

        public ActionResult AdministerCategories()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }

        public ActionResult Delete(int id)
        {
            User user = db.Users.Where(m => m.Id == id).SingleOrDefault();
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Where(m => m.Id == id).SingleOrDefault();
            user.Name = "Użytkownik usunięty";
            user.Email = "";
            user.Hash = new byte[1] {0x01};
            user.IsAdministrator = false;
            user.Location = "";
            user.RemovalDate = DateTime.Now;

            db.SetModified(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Ban(int id)
        {
            User user = db.Users.Where(m => m.Id == id).Single();
            return View(user);
        }

        [HttpPost, ActionName("Ban")]
        public ActionResult BanConfirmed(int id)
        {
            User user = db.Users.Where(m => m.Id == id).Single();
            user.IsBanned = true;
            db.SetModified(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Unban(int id)
        {
            User user = db.Users.Where(m => m.Id == id).Single();
            return View(user);
        }

        [HttpPost, ActionName("Unban")]
        public ActionResult UnbanConfirmed(int id)
        {
            User user = db.Users.Where(m => m.Id == id).Single();
            user.IsBanned = false;
            db.SetModified(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult MyPosts(int userId, int? page)
        {
            IPagedList<Post> posts = db.Posts.Where(m => m.AuthorId == userId).ToList().ToPagedList(page ?? 1, ItemsPerPage());
            return View(posts);
        }

        public JsonResult IsUserNameAvailable(string Name)
        {
            bool result = false;
            try
            {
                User user = db.Users.Where(m => m.Name == Name.ToLower()).Single();
                result = true;
            }
            catch
            {
                result = false;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private byte[] ComputeHash(string data, string salt)
        {            
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(String.Format("{0}{1}",data,salt)));
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

    }
}