using Domain.Models;
using Forum.Controllers;
using NUnit.Framework;
using Tests.FakeRepositories;

namespace Tests
{
    public class WarningControllerTest
    {
        [Test]
        public void Warn()
        {
            FakeWarningRepository context = new FakeWarningRepository();
            FakePostRepository postContext = new FakePostRepository();
            FakeUserRepository userContext = new FakeUserRepository();
            WarningController controller = new WarningController(context, postContext, userContext);

            postContext.posts.Add(new Post { Id = 1 });
            userContext.users.Add(new User { Id = 1 });
            controller.Warn(new Warning { UserId = 1, PostId = 1 });

            Assert.AreEqual(1, context.warnings.Count);
        }
    }
}
