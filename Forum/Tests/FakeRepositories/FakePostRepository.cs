using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakePostRepository : FakeRepository<Post>, IPostRepository
    {
        public List<Post> posts;

        public FakePostRepository()
        {
            posts = new List<Post>();
        }

        public override IEnumerable<Post> Get(System.Linq.Expressions.Expression<Func<Post, bool>> filter = null, Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Post> query = posts.AsQueryable();

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

        public override void Insert(Post entity)
        {
            posts.Add(entity);
        }

        public override void Delete(Post entity)
        {
            posts.Remove(entity);
        }

        public override void Update(Post entity)
        {
            int id = entity.Id;
            posts.RemoveAll(m => m.Id == id);
            posts.Add(entity);
        }
    }
}
