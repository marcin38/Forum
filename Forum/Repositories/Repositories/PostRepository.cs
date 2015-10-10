using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ForumDBContext context) : base(context) { }
    }
}
