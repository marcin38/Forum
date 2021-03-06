﻿using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tests.FakeRepositories
{
    public abstract class FakeRepository<T> : IRepository<T>
    {
        public abstract IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        public abstract void Insert(T entity);

        public abstract void Delete(T entity);

        public abstract void Update(T entity);

        public void Save() { }
    }
}
