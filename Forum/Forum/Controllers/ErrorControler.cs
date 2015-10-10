using Forum.Controllers.Interfaces;
using Forum.Models;
using System;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public partial class ErrorController : Controller, IErrorController
    {
        public virtual ActionResult Index(int statusCode, Exception exception)
        {
            if (statusCode > 0)
            {
                Response.StatusCode = statusCode;
            }
            ErrorModel model = new ErrorModel() { Exception = exception, HttpStatusCode = statusCode };

            return View(model);
        }

    }
}