using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class V_ThreadsRepository : Repository<V_Threads>, IV_ThreadsRepository
    {
        public V_ThreadsRepository(ForumDBContext context) : base(context) { }
    }
}
