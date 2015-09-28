using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IPostController
    {
        ActionResult Index();
        ActionResult AddPost(int threadId);
        ActionResult AddPost(Post post);
        ActionResult EditPost(int id);
        ActionResult EditPost(Post post);
    }
}
