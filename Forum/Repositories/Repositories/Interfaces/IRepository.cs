using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
