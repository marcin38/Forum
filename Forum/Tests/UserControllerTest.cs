using Forum.Controllers;
using Forum.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Tests
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void IndexOrdersByName()
        {
            //var context = new FakeForumDBContext
            //{
            //    Users = 
            //    {
            //        new User {Name = "BBB"},
            //        new User {Name = "AAA"},
            //        new User {Name = "CCC"}
            //    }
            //};

            //var controller = new UserController(context);
            //var result = (ViewResult) controller.Index();

            //var users = (IEnumerable<User>)result.ViewData.Model;
            //Assert.AreEqual("AAA", users.ElementAt(0).Name);
            //Assert.AreEqual("BBB", users.ElementAt(1).Name);
            //Assert.AreEqual("CCC", users.ElementAt(2).Name);
        }
    }
}
