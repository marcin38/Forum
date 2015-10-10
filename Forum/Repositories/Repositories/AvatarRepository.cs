using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class AvatarRepository : Repository<Avatar>, IAvatarRepository
    {
        public AvatarRepository(ForumDBContext context) : base(context) { }
    }
}
