using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumDBContext context) : base(context) { }
    }
}
