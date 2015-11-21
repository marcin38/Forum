using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class RolesUserRepository : Repository<RolesUserRepository>, IRolesUserRepository
    {
        public RolesUserRepository(ForumDBContext context) : base(context) { }

        public IEnumerable<User> GetModerators()
        {
            List<User> moderators = new List<User>();
            try
            {
                int roleId = context.Roles.Where(x => x.Name == "Moderator").Single().Id;
                moderators = context.RolesUsers.Where(x => x.RoleId == roleId).Select(x => x.User).ToList();
            }
            catch(Exception)
            {
                return moderators;
            }

            return moderators;
        }
    }
}
