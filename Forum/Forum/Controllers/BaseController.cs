using Elmah;
using Forum.Authorization;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using System;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    
    public partial class BaseController : Controller, IBaseController
    {
        protected int ItemsPerPage() 
        { 
            return 10;
        }

        protected virtual new CustomPrincipal User
        {
            get 
            {
                if (HttpContext == null)
                    return new CustomPrincipal();
                else
                    return HttpContext.User as CustomPrincipal; 
            }
        }

        protected ActionResult HandleException(Exception ex)
        {
            int statusCode = 500;
            ErrorSignal.FromCurrentContext().Raise(ex);

            return RedirectToAction(MVC.Error.Index(statusCode, ex));
        }
    }
}