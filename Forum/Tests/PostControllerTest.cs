using Domain.Models;
using Forum.Controllers;
using Forum.ViewModels;
using NUnit.Framework;
using System.Linq;
using Tests.FakeRepositories;

namespace Tests
{
    public class PostControllerTest
    {
        [Test]
        public void AddPost()
        {
            FakePostRepository context = new FakePostRepository();
            FakeThreadRepository context2 = new FakeThreadRepository();
            PostController controller = new PostController(context, context2);

            context2.Insert(new Thread { Id = 1 });
            Post post = new Post { ThreadId = 1};
            controller.Add(post);
            Assert.AreEqual(1, context.posts.Count);
        }

        [Test]
        public void EditPost()
        {
            FakePostRepository context = new FakePostRepository();
            FakeThreadRepository context2 = new FakeThreadRepository();
            PostController controller = new PostController(context, context2);

            context2.Insert(new Thread { Id = 1 });
            Post post = new Post { ThreadId = 1};
            controller.Add(post);
            controller.Edit(new PostEditViewModel{PostContent = "content"});
            Assert.AreEqual("content", context.posts.First().PostContent);
        }
    }
}
