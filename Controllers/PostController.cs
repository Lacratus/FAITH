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
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IGebruikerRepository _gebruikerRepository;


    public PostController(IPostRepository postRepository, IGebruikerRepository gebruikerRepository)
        {
            _postRepository = postRepository;
            _gebruikerRepository = gebruikerRepository;
        }

        //GET: api/Post
        /// <summary>
        /// Geeft alle posts weer
        /// </summary>
        /// <returns>
        /// Een lijst met posts
        /// </returns>
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return _postRepository.GetAll();
        }


        // Get: api/Post/id
        /// <summary>
        /// Geeft een post aan de hand van een id
        /// </summary>
        /// <param name="id">
        /// De id van de post
        /// </param>
        /// <returns>
        /// Een post
        /// </returns>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<Post> GetPost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null) return NotFound();
            return post;
        }



        // Post: api/Post
        /// <summary>
        /// Plaats een nieuwe post
        /// </summary>
        /// <param name="post">
        /// De te posten post
        /// </param>
        /// <returns>
        /// De gepostte post
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<Post> PostPost(PostDTO post)
        {
            Gebruiker gebruiker = _gebruikerRepository.GetBy(post.GebruikerEmail);
            if (gebruiker == null) return BadRequest();
            Post postToCreate = new Post(post.Titel, post.Beschrijving, gebruiker.Email);
            gebruiker.VoegPostToe(postToCreate);
            _gebruikerRepository.Update(gebruiker);
            _gebruikerRepository.SaveChanges();
            _postRepository.Add(postToCreate);
            _postRepository.SaveChanges();
            return CreatedAtAction(nameof(GetPost), new { id = postToCreate.Id }, postToCreate);
            }

        // PUT: api/Post/id
        /// <summary>
        /// Update een Post
        /// </summary>
        /// <param name="id">
        /// De id van de te updaten Post
        /// </param>
        /// <param name="post">
        /// De geupdate versie van de Post
        /// </param>
        /// <returns>
        /// De geupdate Post
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult PutPost(int id, Post post)
        {
            if (post.Id != id) return BadRequest();
            _postRepository.Update(post);
            _postRepository.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Post/id
        /// <summary>
        /// Verwijdert een Post
        /// </summary>
        /// <param name="id">
        /// De id van de te verwijderen Post
        /// </param>
        /// <returns>
        /// De verwijderde Post
        /// </returns>
        [HttpDelete("{id}")]
        public ActionResult<Post> DeletePost(int id)
        {
            Post post = _postRepository.GetBy(id);
            if (post == null) return NotFound();
            _postRepository.Delete(post);
            _postRepository.SaveChanges();
            return post;
        }
    }
}
