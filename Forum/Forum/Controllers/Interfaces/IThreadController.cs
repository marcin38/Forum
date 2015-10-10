using Forum.ViewModels;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IThreadController
    {
        ActionResult Index(int id, int? page);
        ActionResult AddThread(int categoryId);
        ActionResult AddThread(ThreadAddThreadViewModel pt);
    }
}
