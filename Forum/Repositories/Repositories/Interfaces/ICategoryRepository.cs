using Domain.Models;
using System.Collections.Generic;

namespace Repositories.Repositories.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<CategoryStatistics> GetCategories();
    }
}
