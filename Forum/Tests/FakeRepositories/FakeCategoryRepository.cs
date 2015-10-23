using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakeCategoryRepository : FakeRepository<Category>, ICategoryRepository
    {
        public List<Category> categories;

        public FakeCategoryRepository()
        {
            categories = new List<Category>();
        }

        public override IEnumerable<Category> Get(System.Linq.Expressions.Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Category> query = categories.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public override void Insert(Category entity)
        {
            categories.Add(entity);
        }

        public override void Delete(Category entity)
        {
            categories.Remove(entity);
        }

        public override void Update(Category entity)
        {
            int id = entity.Id;
            categories.RemoveAll(m => m.Id == id);
            categories.Add(entity);
        }
    }
}
