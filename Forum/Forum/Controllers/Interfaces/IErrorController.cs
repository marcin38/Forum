using System;
using System.Web.Mvc;
namespace Forum.Controllers.Interfaces
{
    interface IErrorController
    {
        ActionResult Index(int statusCode, Exception exception);
    }
}
