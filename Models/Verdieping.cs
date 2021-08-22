using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public class Verdieping
    {
        #region Properties
        public int Id { get; set; }
        public string Beschrijving { get; set; }
        public List<string> Tussenstappen { get; set; }

        #endregion

        #region Constructors
        public Verdieping()
        {

        }

        public Verdieping(string beschrijving)
        {
            Beschrijving = beschrijving;
        }


        #endregion

        #region Methods
        public void VoegTussenstapToe(string tussenstap)
        {
            Tussenstappen.Add(tussenstap);
        }       
        #endregion
    }
}
