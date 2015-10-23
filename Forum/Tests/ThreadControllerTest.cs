using Forum.Controllers;
using Forum.ViewModels;
using NUnit.Framework;
using Tests.FakeRepositories;

namespace Tests
{
    public class ThreadControllerTest
    {
        [Test]
        public void AddThread()
        {
            FakeThreadRepository context = new FakeThreadRepository();
            FakePostRepository postContext = new FakePostRepository();
            ThreadController controller = new ThreadController(context, postContext);

            ThreadAddThreadViewModel model = new ThreadAddThreadViewModel();
            controller.AddThread(model);
            Assert.AreEqual(1, context.threads.Count);
        }
    }
}
