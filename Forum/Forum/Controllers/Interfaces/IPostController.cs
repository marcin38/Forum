using Domain.Models;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IPostController
    {
        ActionResult AddPost(int threadId);
        ActionResult AddPost(Post post);
        ActionResult EditPost(int id);
        ActionResult EditPost(Post post);
        ActionResult ShowPost(int id);
    }
}
