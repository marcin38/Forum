using Domain.Models;
using System.Collections.Generic;

namespace Repositories.Repositories.Interfaces
{
    public interface IThreadRepository : IRepository<Thread>
    {
        IEnumerable<ThreadStatistics> GetThreadsByCategoryId(int categoryId);
    }
}
