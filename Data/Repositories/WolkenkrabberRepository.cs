using FAITHAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Data.Repositories
{
    public class WolkenkrabberRepository : IWolkenkrabberRepository
    {
        private readonly FAITHContext _context;
        private readonly DbSet<Wolkenkrabber> _wolkenkrabbers;

        public WolkenkrabberRepository(FAITHContext dbContext)
        {
            _context = dbContext;
            _wolkenkrabbers = dbContext.Wolkenkrabbers;
        }

        public void Add(Wolkenkrabber wolkenkrabber)
        {
            _wolkenkrabbers.Add(wolkenkrabber);
        }

        public void Delete(Wolkenkrabber wolkenkrabber)
        {
            _wolkenkrabbers.Remove(wolkenkrabber);
        }

        public IEnumerable<Wolkenkrabber> GetAll()
        {
            return _wolkenkrabbers.ToList();
        }

        public Wolkenkrabber GetBy(int id)
        {
            return _wolkenkrabbers.SingleOrDefault(w => w.Id == id);
        }

        public Wolkenkrabber GetBy(string email)
        {
            return _wolkenkrabbers.SingleOrDefault(w => w.Gebruiker.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Wolkenkrabber wolkenkrabber)
        {
            _context.Update(wolkenkrabber);
        }
    }
}
