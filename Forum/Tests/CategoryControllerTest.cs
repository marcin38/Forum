using System;
using NUnit.Framework;
using Forum.Controllers;
using Tests.FakeRepositories;
using Repositories.Repositories.Interfaces;
using Domain.Models;

namespace Tests
{
    //Convention
    //MethodName_StateUnderTest_ExpectedBehavior

    //Examples
    //Public void Sum_NegativeNumberAs1stParam_ExceptionThrown() 

    //Public void Sum_NegativeNumberAs2ndParam_ExceptionThrown () 

    //Public void Sum_simpleValues_Calculated ()


    [TestFixture]
    public class CategoryControllerTest
    {
        [Test]
        public void Create()
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
            FakeCategoryRepository context = new FakeCategoryRepository();
            CategoryController controller = new CategoryController(null,context,null,null);


            controller.Create(new Category());
            controller.Create(new Category());
            Assert.AreEqual(2, context.categories.Count);
            //var result = (ViewResult) controller.Index();

            //var users = (IEnumerable<User>)result.ViewData.Model;
            //Assert.AreEqual("AAA", users.ElementAt(0).Name);
            //Assert.AreEqual("BBB", users.ElementAt(1).Name);
            //Assert.AreEqual("CCC", users.ElementAt(2).Name);
        }
    }
}
