using Domain.Models;
using Repositories.Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class WarningRepository : Repository<Warning>, IWarningRepository
    {
        public WarningRepository(ForumDBContext context) : base(context) { }
    }
}
