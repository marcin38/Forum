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
        IDbSet<Category> Categories { get; set; }
        IDbSet<Post> Posts { get; set; }
        IDbSet<Thread> Threads { get; set; }
        IDbSet<V_Categories> V_Categories { get; set; }
        IDbSet<V_Threads> V_Threads { get; set; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
