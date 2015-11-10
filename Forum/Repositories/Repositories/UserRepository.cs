using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Data.SqlClient;

namespace Repositories.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ForumDBContext context) : base(context){ }        
    }
}
