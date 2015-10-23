using Domain.Models;
using Forum.Controllers.Interfaces;
using Forum.Exceptions;
using PagedList;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize(Roles = "Administrator")]
    public partial class CategoryController : BaseController, ICategoryController
    {
        private IV_ThreadsRepository v_threadsRepository;
        private ICategoryRepository categoryRepository;

        public CategoryController() { }

        public CategoryController(IV_ThreadsRepository v_threadsRepository, ICategoryRepository categoryRepository)
        {
            this.v_threadsRepository = v_threadsRepository;
            this.categoryRepository = categoryRepository;
        }

        [AllowAnonymous]
        public virtual ActionResult Index(int id, int? page)
        {
            try
            {
                IPagedList<V_Threads> threads = v_threadsRepository.Get(m => m.CategoryId == id, m => m.OrderByDescending(x => x.WhenAddedLastPost))
                    .ToList()
                    .ToPagedList(page ?? 1, ItemsPerPage());

                return View(threads);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryRepository.Insert(category);
                    categoryRepository.Save();

                    return RedirectToAction(MVC.User.AdministerCategories());
                }

                return View(category);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public virtual ActionResult Edit(int id)
        {
            try
            {
                Category category = GetCategoryById(id);

                return View(category);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryRepository.Update(category);
                    categoryRepository.Save();

                    return RedirectToAction(MVC.User.AdministerCategories());
                }

                return View(category);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        public virtual ActionResult Delete(int id)
        {
            try
            {
                Category category = GetCategoryById(id);

                return View(category);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Category category = GetCategoryById(id);

                if (ModelState.IsValid)
                {
                    categoryRepository.Delete(category);
                    categoryRepository.Save();

                    return RedirectToAction(MVC.User.AdministerCategories());
                }

                return View(category);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        private Category GetCategoryById(int id)
        {
            Category category = categoryRepository.Get(m => m.Id == id).FirstOrDefault();
            if (category == null)
            {
                throw new MyException(-1);
            }
            return category;
        }

    }
}