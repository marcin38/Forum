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
    }

    
}