using Forum.Models;
using System;
using System.Data.Entity;

namespace Forum.Models
{
    public partial class ForumDBContext : DbContext, IForumDBContext
    {
        //public StoreAppContext()
        //    : base("name=StoreAppContext")
        //{
        //}

        //public DbSet<Product> Products { get; set; }

        //public void MarkAsModified(Product item)
        //{
        //    Entry(item).State = EntityState.Modified;
        //}

        public virtual IDbSet<Avatar> Avatars { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Post> Posts { get; set; }
        public virtual IDbSet<Thread> Threads { get; set; }
        public virtual IDbSet<V_Categories> V_Categories { get; set; }
        public virtual IDbSet<V_Threads> V_Threads { get; set; }
        public virtual void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }

    
}