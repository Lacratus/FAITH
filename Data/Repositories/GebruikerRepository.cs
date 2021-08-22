using FAITHAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly FAITHContext _context;
        private readonly DbSet<Gebruiker> _gebruikers;

        public GebruikerRepository(FAITHContext dbContext)
        {
            _context = dbContext;
            _gebruikers = dbContext.Gebruikers;
        }

        public void Add(Gebruiker gebruiker)
        {
            _gebruikers.Add(gebruiker);
        }

        public void Delete(Gebruiker gebruiker)
        {
            _gebruikers.Remove(gebruiker);
        }

        public IEnumerable<Gebruiker> GetAll()
        {
            return _gebruikers.Include(b => b.Wolkenkrabber).ToList();
        }

        public Gebruiker GetBy(int id)
        {
            return _gebruikers.Include(b => b.Wolkenkrabber).SingleOrDefault(b => b.Id == id);
        }

        public Gebruiker GetBy(string email)
        {
            return _gebruikers.Include(b => b.Wolkenkrabber).SingleOrDefault(b => b.Email == email);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Gebruiker gebruiker)
        {
            _context.Update(gebruiker);
        }
    }
}
