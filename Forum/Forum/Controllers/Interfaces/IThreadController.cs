using Forum.Models;
using Forum.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
