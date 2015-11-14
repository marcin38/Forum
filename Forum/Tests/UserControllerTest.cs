using Forum.Controllers;
using Forum.ViewModels;
using NUnit.Framework;
using System.Linq;
using Tests.FakeRepositories;

namespace Tests
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
        public void Register()
        {
            FakeUserRepository context = new FakeUserRepository();
            UserController controller = new UserController(context, null, null, null);

            UserRegisterViewModel user = new UserRegisterViewModel();
            controller.Register(user, null);
            Assert.AreEqual(1, context.users.Count);
        }

        [Test]
        public void EditProfile()
        {
            FakeUserRepository context = new FakeUserRepository();
            UserController controller = new UserController(context, null, null, null);

            UserRegisterViewModel user = new UserRegisterViewModel { Id = 0 };
            controller.Register(user, null);

            UserEditProfileViewModel user2 = new UserEditProfileViewModel { Id = 0, Location = "abc" };
            controller.EditProfile(user2, null);
            Assert.AreEqual("abc", context.users.First().Location);
        }

        [Test]
        public void DeleteConfirmed()
        {
            FakeUserRepository context = new FakeUserRepository();
            UserController controller = new UserController(context, null, null, null);

            UserRegisterViewModel user = new UserRegisterViewModel { Id = 1 };
            controller.Register(user, null);
            UserRegisterViewModel user2 = new UserRegisterViewModel { Id = 2 };
            controller.Register(user2, null);

            controller.DeleteConfirmed(1);
            Assert.AreEqual(2, context.users.First().Id);
        }

        [Test]
        public void BanConfirmed()
        {
            FakeUserRepository context = new FakeUserRepository();
            UserController controller = new UserController(context, null, null, null);

            UserRegisterViewModel user = new UserRegisterViewModel { Id = 1 };
            controller.Register(user, null);
            UserRegisterViewModel user2 = new UserRegisterViewModel { Id = 2 };
            controller.Register(user2, null);

            controller.BanConfirmed(1);
            Assert.AreEqual(true, context.Get(x => x.Id == 1).First().IsBanned);
            Assert.AreEqual(false, context.Get(x => x.Id == 2).First().IsBanned);
        }

        [Test]
        public void UnbanConfirmed()
        {
            FakeUserRepository context = new FakeUserRepository();
            UserController controller = new UserController(context, null, null, null);

            UserRegisterViewModel user = new UserRegisterViewModel { Id = 1 };
            controller.Register(user, null);
            UserRegisterViewModel user2 = new UserRegisterViewModel { Id = 2 };
            controller.Register(user2, null);
            controller.BanConfirmed(1);
            controller.BanConfirmed(1);
            controller.UnbanConfirmed(2);

            Assert.AreEqual(true, context.Get(x => x.Id == 1).First().IsBanned);
            Assert.AreEqual(false, context.Get(x => x.Id == 2).First().IsBanned);

        }
    }
}
