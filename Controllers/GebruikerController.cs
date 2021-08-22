using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAITHAPI.DTOs;
using FAITHAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAITHAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "admin")]
    public class GebruikerController : ControllerBase
    {
        private IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IGebruikerRepository gebruikerRepository)
        {
            _gebruikerRepository = gebruikerRepository;
        }

        // GET: api/Gebruiker
        /// <summary>
        /// Get voor alle gebruiker
        /// </summary>
        /// <returns>
        /// Lijst met gebruiker
        /// </returns>
        [HttpGet]
        public IEnumerable<Gebruiker> GetGebriukers()
        {
            return _gebruikerRepository.GetAll();
        }

        //GET: api/Gebruiker/id
        /// <summary>
        /// Get voor gebruiker op basis van id
        /// </summary>
        /// <param name="id">
        /// De id van de gebruiker
        /// </param>
        /// <returns>
        /// De gebruiker met gevraagde id
        /// </returns>
        [HttpGet("{id}")]
        public ActionResult<Gebruiker> GetBy(int id)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(id);
            if (gebruiker == null) return BadRequest();
            return gebruiker;
        }

        //GET: api/Gebruiker/email/email
        /// <summary>
        /// Zoekt een gebruiker op basis van email adres
        /// </summary>
        /// <param name="email">
        /// De email van de gebruiker
        /// </param>
        /// <returns>
        /// Gebruiker met gegeven email
        /// </returns>
        [HttpGet("email/{email}")]
        public ActionResult<Gebruiker> GetBy(string email)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(email);
            if (gebruiker == null) return BadRequest();
            return gebruiker;
        }

        // POST: api/Gebruiker
        /// <summary>
        /// Post een Gebruiker
        /// </summary>
        /// <param name="gebruiker">
        /// De te posten Gebruiker
        /// </param>
        /// <returns>
        /// De aangemaakte Gebruiker
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Gebruiker> PostGebruiker(GebruikerDTO gebruiker)
        {
            Gebruiker gebruikerToBeCreated = new Gebruiker(gebruiker.Firstname, gebruiker.Lastname, gebruiker.Email, gebruiker.Country, gebruiker.City, gebruiker.Street, gebruiker.StreetNr);
            _gebruikerRepository.Add(gebruikerToBeCreated);
            _gebruikerRepository.SaveChanges();
            return CreatedAtAction(nameof(GebruikerController), new { id = gebruikerToBeCreated.Id }, gebruikerToBeCreated);
        }

        // PUT: api/Gebruiker/id
        /// <summary>
        /// Update een gebruiker met gegeven id
        /// </summary>
        /// <param name="id">
        /// De id van de te updaten gebruiker
        /// </param>
        /// <param name="gebruiker">
        /// De geupdate gebruiker
        /// </param>
        /// <returns>
        /// De geupdate gebruiker
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult PutGebruiker(int id, Gebruiker gebruiker)
        {
            if (id != gebruiker.Id) return BadRequest();
            _gebruikerRepository.Update(gebruiker);
            _gebruikerRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Gebruiker/id
        /// <summary>
        /// verwijdert de gebruiker met gegeven id
        /// </summary>
        /// <param name="id">
        /// De id van de te verwijderen gebruiker
        /// </param>
        /// <returns>
        /// De verwijderde gebruiker
        /// </returns>
        [HttpDelete("{id}")]
        public ActionResult<Gebruiker> DeleteGebruiker(int id)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(id);
            if (gebruiker == null) return NotFound();
            _gebruikerRepository.Delete(gebruiker);
            _gebruikerRepository.SaveChanges();
            return gebruiker;
        }

        // GET: api/Gebruiker/id/Posts
        /// <summary>
        /// Geeft de lijst van Posts van een Gebruiker
        /// </summary>
        /// <param name="id">
        /// De id van de gebruiker waarvan de posts worden opgevraagd
        /// </param>
        /// <returns>
        /// Een lijst met posts
        /// </returns>
        [HttpGet("{id}/Posts")]
        public IEnumerable<Post> GetPostsGebruiker(int id)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(id);
            return gebruiker.Posts;
        }

        // GET: api/Gebruiker/gebruikerId/Posts/postId
        /// <summary>
        /// Geeft een Post van een Gebruiker
        /// </summary>
        /// <param name="gebruikerId">
        /// De id van de gebruiker waarvan men een post wenst op te vragen
        /// </param>
        /// <param name="postId">
        /// De id van de post
        /// </param>
        /// <returns>
        /// De post
        /// </returns>
        [HttpGet("{gebruikerId}/Posts/{postId}")]
        public ActionResult<Post> GetPostGebruiker(int gebruikerId, int postId)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(gebruikerId);
            if (gebruiker == null) return NotFound();
            Post post = gebruiker.Posts.SingleOrDefault(b => b.Id == postId);
            if (post == null) return NotFound();
            return post;
        }
    }
}
