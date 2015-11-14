using Domain.Models;
using Forum.Controllers;
using NUnit.Framework;
using System.Linq;
using Tests.FakeRepositories;

namespace Tests
{

    [TestFixture]
    public class CategoryControllerTest
    {
        [Test]
        public void Create()
        {
            FakeCategoryRepository context = new FakeCategoryRepository();
            CategoryController controller = new CategoryController(null, context);

            controller.Create(new Category());
            controller.Create(new Category());
            Assert.AreEqual(2, context.categories.Count);
        }

        [Test]
        public void Edit()
        {
            FakeCategoryRepository context = new FakeCategoryRepository();
            CategoryController controller = new CategoryController(null, context);

            Category category = new Category { Id = 1, Name = "test" };
            controller.Create(category);

            category.Name = "2";
            controller.Edit(category);
            Assert.AreEqual("2", context.Get().First().Name);
        }

        [Test]
        public void DeleteConfirmed()
        {
            FakeCategoryRepository context = new FakeCategoryRepository();
            CategoryController controller = new CategoryController(null, context);

            controller.Create(new Category { Id = 1 });
            controller.Create(new Category { Id = 2 });

            controller.DeleteConfirmed(1);
            Assert.AreEqual(1, context.categories.Count);
            Assert.AreEqual(2, context.Get().First().Id);
        }
    }
}
