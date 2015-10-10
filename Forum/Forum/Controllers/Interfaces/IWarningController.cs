using Domain.Models;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IWarningController
    {
        ActionResult Index(int id);
        ActionResult Warn(Warning warning);
        ActionResult Warn(int postId);
    }
}
