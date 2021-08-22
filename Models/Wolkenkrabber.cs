using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public class Wolkenkrabber
    {
        #region Properties
        public int Id { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public List<Verdieping> Verdiepingen { get; set; }

        #endregion

        #region Constructors
        public Wolkenkrabber()
        {
            Verdiepingen = new List<Verdieping>();
        }
        #endregion

        #region Methods
        public void VoegVerdiepingToe(Verdieping verdieping)
        {
            Verdiepingen.Add(verdieping);

        }       
        #endregion
    }
}
