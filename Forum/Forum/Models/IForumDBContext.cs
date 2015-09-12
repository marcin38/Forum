using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public interface IForumDBContext : IDisposable
    {
        IDbSet<Avatar> Avatars { get; set; }
        IDbSet<User> Users { get; set; }
        int SaveChanges();
    }
}
