using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class V_CategoriesRepository : Repository<V_Categories>, IV_CategoriesRepository
    {
        public V_CategoriesRepository(ForumDBContext context) : base(context) { }
    }
}
