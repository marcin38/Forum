using Forum.Models;
using System;

namespace Forum.Controllers.Interfaces
{
    interface IWarningController
    {
        System.Web.Mvc.ActionResult Index(int id);
        System.Web.Mvc.ActionResult Warn(Warning warning);
        System.Web.Mvc.ActionResult Warn(int postId);
    }
}
