using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakeUserRepository : FakeRepository<User>, IUserRepository
    {
        public List<User> users;

        public FakeUserRepository()
        {
            users = new List<User>();
        }

        public override IEnumerable<User> Get(System.Linq.Expressions.Expression<Func<User, bool>> filter = null, Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null, string includeProperties = "")
        {
            IQueryable<User> query = users.AsQueryable();

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

        public override void Insert(User entity)
        {
            users.Add(entity);
        }

        public override void Delete(User entity)
        {
            users.Remove(entity);
        }

        public override void Update(User entity)
        {
            int id = entity.Id;
            users.RemoveAll(m => m.Id == id);
            users.Add(entity);
        }
    }
}
