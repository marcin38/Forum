using Domain.Models;
using Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repositories
{
    public class ThreadStatistics
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public DateTime WhenAddedLastPost { get; set; }
        public string WhoAddedLastPost { get; set; }
        public int PostsNumber { get; set; }
        public string LastPost { get; set; }
    }

    public class ThreadRepository : Repository<Thread>, IThreadRepository
    {
        public ThreadRepository(ForumDBContext context) : base(context) { }



        public IEnumerable<ThreadStatistics> GetThreadsByCategoryId(int categoryId)
        {
            var threads = (from t in context.Threads
                          join p in context.Posts on t.Id equals p.ThreadId
                          join u in context.Users on p.AuthorId equals u.Id
                          where t.CategoryId == categoryId && p.Id == t.LastPost 
                          select new ThreadStatistics
                          {
                              CategoryId = categoryId,
                              Id = t.Id,
                              LastPost = p.PostContent.Substring(0,100) + "...",
                              PostsNumber = t.Posts.Count(),
                              Title = t.Title,
                              WhenAddedLastPost = p.CreationDate,
                              WhoAddedLastPost = u.Name
                          }).OrderByDescending(m => m.WhenAddedLastPost);

            return threads;
        }
    }
}
