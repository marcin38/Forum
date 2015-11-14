using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repositories
{
    public class CategoryStatistics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ThreadsNumber { get; set; }
        public int PostsNumber { get; set; }
        public string LastPost { get; set; }
        public int LastPostId { get; set; }
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ForumDBContext context) : base(context) { }

        public IEnumerable<CategoryStatistics> GetCategories()
        {
            var categories =(from c in context.Categories
                     join t in context.Threads on c.Id equals t.CategoryId
                     join p in context.Posts on t.Id equals p.ThreadId
                     select new
                     {
                         Id = c.Id,
                         Description = c.Description,
                         Name = c.Name,
                         ThreadsNumber = c.Threads.Count(),
                         PostId = p.Id,
                     } into row
                     group row by new { row.Id, row.Name, row.Description, row.ThreadsNumber } into r
                     select
                     new CategoryStatistics
                     {
                         Id = r.Key.Id,
                         Description = r.Key.Description,
                         Name = r.Key.Name,
                         PostsNumber = r.Count(),
                         ThreadsNumber = r.Key.ThreadsNumber,
                         LastPostId = r.Max(x => x.PostId)
                     }).OrderBy(x => x.Id).ToList();

            categories.ForEach(x => x.LastPost = GetUserNameAndDateFromPostId(x.LastPostId));

            return categories;       
        }

        private string GetUserNameAndDateFromPostId(int id)
        {
            Post post = context.Posts.Where(x => x.Id == id).Single();
            return post.CreationDate.ToString() + " by " + context.Users.Where(x => x.Id == post.AuthorId).Single().Name;
        }
    }

    
}
