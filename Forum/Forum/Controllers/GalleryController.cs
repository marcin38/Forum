using Forum.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public partial class GalleryController : BaseController, IGalleryController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}