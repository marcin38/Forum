using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ForumDBContext context) : base(context){ }

        public IEnumerable<string> GetRolesForUser(string username)
        {
            List<string> roleNames = new List<string>();
            User user = null;

            List<User> users = Get(x => x.Name == username).ToList();
            if (users.Count == 1)
            {
                user = users.First();
                roleNames = user.RolesUsers.Select(x => x.Role.Name).ToList();
                
                roleNames.Add("User");
            }
            return roleNames;
        }

    }
}
