using Domain.Models;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface ICategoryController
    {
        ActionResult Index(int id, int? page);
        ActionResult Create();
        ActionResult Create(Category category);
        ActionResult Edit(int id);
        ActionResult Edit(Category category);
        ActionResult Delete(int id);
        ActionResult DeleteConfirmed(int id);
    }
}
