using Domain.Models;
using Forum.ViewModels;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface IPostController
    {
        ActionResult Add(Post post);
        ActionResult Edit(PostEditViewModel post);
        ActionResult ShowPost(int id);
    }
}
