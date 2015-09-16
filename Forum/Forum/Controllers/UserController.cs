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
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace Forum.Controllers
{
    public class UserController : BaseController, IUserController
    {
        private IForumDBContext db;
        //public UserManager<ApplicationUser> UserManager { get; private set; }

        public UserController()
        {
            db = new ForumDBContext();
        }

        public UserController(IForumDBContext db)
        {
            this.db = db;
        }

        public ActionResult Index()
        {
            return View(db.Users.OrderBy(m => m.Name).ToList());
        }

        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Hash = ComputeHash(user.Password, user.Name);
                user.RegistrationDate = System.DateTime.Now;
                db.Users.Add(user);                
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
                    user.Password = credentials.Password;
                    SaveCookie(user);
                    //var u = new ApplicationUser() { UserName = user.Name};
                    //var result = await UserManager.CreateAsync(u, credentials.Password);
                    //await SignIn(u, false);
                    return RedirectToAction("Index", "Home");
                }

            }

            return View(credentials);
        }

//        public ActionResult LogOff()
//        {
//            AuthenticationManager.SignOut();
//            return RedirectToAction("Index", "Home");
//        }

//        private async Task SignIn(ApplicationUser user, bool isPersistent)
//        {
            
////            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
//            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);

////            HttpContext.User = new ClaimsPrincipal(AuthenticationManager.AuthenticationResponseGrant.Principal);
//        }

//        private IAuthenticationManager AuthenticationManager
//        {
//            get
//            {
//                return HttpContext.GetOwinContext().Authentication;
//            }
//        }

        private byte[] ComputeHash(string data, string salt)
        {
            
            //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            //StreamReader reader = new StreamReader(@"D:\git\Forum\PublicOnlyKey.xml");
            //string publicOnlyKeyXML = reader.ReadToEnd();
            //rsa.FromXmlString(publicOnlyKeyXML);
            //reader.Close();
            
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(String.Format("{0}{1}",data,salt)));
            return hash;
        }

        private void SaveCookie(User user)
        {
            HttpCookie cookie = new HttpCookie("f_user");
            cookie.Values["Name"] = user.Name;
            cookie.Values["Password"] = user.Password;
            HttpContext.Response.Cookies.Add(cookie);
        }

        
    }
}