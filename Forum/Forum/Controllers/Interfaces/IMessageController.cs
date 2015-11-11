using Domain.Models;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IMessageController
    {
        ActionResult Index(string type, string sortOrder, int? page);
        ActionResult Send();
        ActionResult Send(Message message);
        EmptyResult Read(int id);
        ActionResult Delete(int id);
        ActionResult DeleteConfirmed(int id);
    }
}
