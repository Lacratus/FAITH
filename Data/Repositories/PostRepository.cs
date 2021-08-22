using FAITHAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace  FAITHAPI.Data.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly FAITHContext _context;
        private readonly DbSet<Post> _posts;

        public PostRepository(FAITHContext dbContext)
        {
            this._context = dbContext;
            this._posts = dbContext.Posts;
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts.ToList();
        }

        public Post GetBy(int id)
        {
            return _posts.SingleOrDefault(b => b.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Update(post);
        }
    }
}
