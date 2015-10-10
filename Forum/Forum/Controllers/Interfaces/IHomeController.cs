using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IHomeController
    {
        ActionResult Index();
        ActionResult About();
        ActionResult Contact();
        ActionResult Search(string searchBy, string search, int? page);
    }
}
