using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public interface IPostRepository
    {
        Post GetBy(int id);
        IEnumerable<Post> GetAll();
        void Add(Post post);
        void Delete(Post post);
        void Update(Post post);
        void SaveChanges();
    }
}
