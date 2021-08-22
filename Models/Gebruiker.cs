using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Models
{
    public class Gebruiker
    {
        #region Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string StreetNr { get; set; }
        public Wolkenkrabber Wolkenkrabber { get; set; }
        public List<Post> Posts { get; set; }
        #endregion

        #region Constructors
        public Gebruiker() {
            Posts = new List<Post>();
        }

        public Gebruiker(string firstName,string lastName, string email, string country, string city, string street, string streetNr)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Country = country;
            City = city;
            Street = street;
            StreetNr = streetNr;
            // Wolkenkrabber = wolkenkrabber;
            Posts = new List<Post>();
        }
        #endregion
        #region Methods
        public void VoegPostToe(Post post)
        {
            Posts.Add(post);

        }
        #endregion
    }
}
