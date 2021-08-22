using FAITHAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Data.Repositories
{
    public class VerdiepingRepository : IVerdiepingRepository
    {
        private readonly FAITHContext _context;
        private readonly DbSet<Verdieping> _verdiepingen;

        public VerdiepingRepository(FAITHContext dbContext)
        {
            _context = dbContext;
            _verdiepingen = dbContext.Verdiepingen;
        }

        public void Add(Verdieping verdieping)
        {
            _verdiepingen.Add(verdieping);
        }

        public void Delete(Verdieping verdieping)
        {
            _verdiepingen.Remove(verdieping);
        }

        public IEnumerable<Verdieping> GetAll()
        {
            return _verdiepingen.ToList();
        }

        public Verdieping GetBy(int id)
        {
            return _verdiepingen.SingleOrDefault(w => w.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Verdieping verdieping)
        {
            _context.Update(verdieping);
        }
    }
}
