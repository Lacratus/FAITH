using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public interface IWolkenkrabberRepository

    {
        Wolkenkrabber GetBy(int id );
        Wolkenkrabber GetBy(string email);
        IEnumerable<Wolkenkrabber> GetAll();
        void Add(Wolkenkrabber wolkenkrabber);
        void Delete(Wolkenkrabber wolkenkrabber);
        void Update(Wolkenkrabber wolkenkrabber);
        void SaveChanges();
    }
}
