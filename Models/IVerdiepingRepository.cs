using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public interface IVerdiepingRepository

    {
        Verdieping GetBy(int id);
        IEnumerable<Verdieping> GetAll();
        void Add(Verdieping verdieping);
        void Delete(Verdieping verdieping);
        void Update(Verdieping verdieping);
        void SaveChanges();
    }
}
