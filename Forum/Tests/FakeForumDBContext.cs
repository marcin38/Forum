using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class FakeForumDBContext : IForumDBContext
    {
        public FakeForumDBContext()
        {
            this.Avatars = new FakeAvatarSet();
            this.Users = new FakeUserSet();
        }

        public IDbSet<Avatar> Avatars
        {get; set;}

        public IDbSet<User> Users
        { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
