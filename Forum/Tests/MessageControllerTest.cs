using Domain.Models;
using Forum.Controllers;
using NUnit.Framework;
using System.Linq;
using Tests.FakeRepositories;

namespace Tests
{
    public class MessageControllerTest
    {
        [Test]
        public void Send()
        {
            FakeMessageRepository context = new FakeMessageRepository();
            MessageController controler = new MessageController(context, null);

            Message message = new Message { Id = 1, To = 1 };
            controler.Send(message);
            Assert.AreEqual(1, context.messages.Count);
        }

        [Test]
        public void DeleteConfirmed()
        {
            FakeMessageRepository context = new FakeMessageRepository();
            MessageController controler = new MessageController(context, null);

            Message message = new Message { Id = 1, To = 1 };
            controler.Send(message);
            Message message2 = new Message { Id = 2, To = 2 };
            controler.Send(message2);
            controler.DeleteConfirmed(1);
            Assert.AreEqual(2, context.Get().First().Id);

        }
    }
}
