using Domain.Models;
using Forum.Controllers;
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
            PostController controller = new PostController(context);

            Post post = new Post();
            controller.AddPost(post);
            Assert.AreEqual(1, context.posts.Count);
        }

        [Test]
        public void EditPost()
        {
            FakePostRepository context = new FakePostRepository();
            PostController controller = new PostController(context);

            Post post = new Post();
            controller.AddPost(post);
            post.PostContent = "content";
            Assert.AreEqual("content", context.posts.First().PostContent);
        }
    }
}
