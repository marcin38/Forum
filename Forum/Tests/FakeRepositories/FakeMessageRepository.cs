using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests.FakeRepositories
{
    public class FakeMessageRepository : FakeRepository<Message>, IMessageRepository
    {
        public List<Message> messages;

        public FakeMessageRepository()
        {
            messages = new List<Message>();
        }

        public override IEnumerable<Message> Get(System.Linq.Expressions.Expression<Func<Message, bool>> filter = null, Func<IQueryable<Message>, IOrderedQueryable<Message>> orderBy = null, string includeProperties = "")
        {
            IQueryable<Message> query = messages.AsQueryable();

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

        public override void Insert(Message entity)
        {
            messages.Add(entity);
        }

        public override void Delete(Message entity)
        {
            messages.Remove(entity);
        }

        public override void Update(Message entity)
        {
            int id = entity.Id;
            messages.RemoveAll(m => m.Id == id);
            messages.Add(entity);
        }
    }
}
