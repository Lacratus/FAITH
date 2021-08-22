using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public interface IGebruikerRepository
    {
        Gebruiker GetBy(int id);
        Gebruiker GetBy(string email);
        IEnumerable<Gebruiker> GetAll();
        void Add(Gebruiker gebruiker);
        void Delete(Gebruiker gebruiker);
        void Update(Gebruiker gebruiker);
        void SaveChanges();
    }
}
