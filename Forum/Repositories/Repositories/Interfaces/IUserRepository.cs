using Domain.Models;
using System.Collections.Generic;

namespace Repositories.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<string> GetRolesForUser(string username);
    }
}
