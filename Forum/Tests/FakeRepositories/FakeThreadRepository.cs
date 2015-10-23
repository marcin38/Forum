using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakeThreadRepository : FakeRepository<Thread>, IThreadRepository
    {
        public List<Thread> threads;

        public FakeThreadRepository()
        {
            threads = new List<Thread>();
        }

        public override IEnumerable<Thread> Get(System.Linq.Expressions.Expression<Func<Thread, bool>> filter = null, Func<IQueryable<Thread>, IOrderedQueryable<Thread>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Thread> query = threads.AsQueryable();

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

        public override void Insert(Thread entity)
        {
            threads.Add(entity);
        }

        public override void Delete(Thread entity)
        {
            threads.Remove(entity);
        }

        public override void Update(Thread entity)
        {
            int id = entity.Id;
            threads.RemoveAll(m => m.Id == id);
            threads.Add(entity);
        }

    }
}
