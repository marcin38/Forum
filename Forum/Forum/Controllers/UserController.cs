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

namespace Forum.Controllers
{
    public class UserController : Controller, IUserController
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

        // GET: User
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
                db.Users.Add(user);
                user.Hash = ComputeHash(user.Password, user.Name);
                user.RegistrationDate = System.DateTime.Now;
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
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(credentials);
        }

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
    }
}