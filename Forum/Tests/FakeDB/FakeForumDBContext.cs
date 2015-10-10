using Domain.Models;
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class FakeForumDBContext
    {
        public FakeForumDBContext()
        {
            this.Avatars = new List<Avatar>();
            this.Categories = new List<Category>();
            this.Users = new List<User>();
            

        //public virtual DbSet<Message> Messages { get; set; }
        //public virtual DbSet<Post> Posts { get; set; }
        //public virtual DbSet<Thread> Threads { get; set; }
        //public virtual DbSet<Warning> Warnings { get; set; }
        //public virtual DbSet<V_Categories> V_Categories { get; set; }
        //public virtual DbSet<V_Threads> V_Threads { get; set; }
        }

        List<Avatar> Avatars { get; set; }
        List<User> Users { get; set; }
        List<Category> Categories { get; set; }
        List<Post> Posts { get; set; }
        List<Thread> Threads { get; set; }
        List<V_Categories> V_Categories { get; set; }
        List<V_Threads> V_Threads { get; set; }
        List<Message> Messages { get; set; }
        List<Warning> Warnings { get; set; }

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
