using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Forum.Controllers.Interfaces
{
    interface ICategoryController
    {
        ActionResult Index(int id, int? page);
        ActionResult Create();
        ActionResult Create(Category category);
        ActionResult Edit(int id);
        ActionResult Delete(int id);
        ActionResult DeleteConfirmed(int id);
    }
}
