using Domain.Models;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IMessageController
    {
        ActionResult Index(string type, int? page);
        ActionResult Send();
        ActionResult Send(Message message);
        ActionResult Show(int id);
        ActionResult Delete(int id);
        ActionResult DeleteConfirmed(int id);
    }
}
