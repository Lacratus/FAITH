using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public class Post
    {
        #region Properties
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }
        public string GebruikerEmail { get; set; }

        #endregion

        #region Constructors
        public Post()
        {

        }

        public Post(string titel, string beschrijving, string gebruikerEmail)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            GebruikerEmail = gebruikerEmail;
        }


        #endregion
    }
}
