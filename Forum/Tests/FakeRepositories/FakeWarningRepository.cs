using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakeWarningRepository : FakeRepository<Warning>, IWarningRepository
    {
        public List<Warning> warnings;

        public FakeWarningRepository()
        {
            warnings = new List<Warning>();
        }

        public override IEnumerable<Warning> Get(System.Linq.Expressions.Expression<Func<Warning, bool>> filter = null, Func<IQueryable<Warning>, IOrderedQueryable<Warning>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Warning> query = warnings.AsQueryable();

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

        public override void Insert(Warning entity)
        {
            warnings.Add(entity);
        }

        public override void Delete(Warning entity)
        {
            warnings.Remove(entity);
        }

        public override void Update(Warning entity)
        {
            int postId = entity.PostId;
            int userId = entity.UserId;
            warnings.RemoveAll(m => m.PostId == postId && m.UserId == userId);
            warnings.Add(entity);
        }
    }
}
