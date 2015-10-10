using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ThreadRepository : Repository<Thread>, IThreadRepository
    {
        public ThreadRepository(ForumDBContext context) : base(context) { }
    }
}
