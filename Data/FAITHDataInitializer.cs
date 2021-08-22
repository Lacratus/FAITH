using FAITHAPI.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FAITHAPI.Data
{
    public class FAITHDataInitializer
    {
        private readonly FAITHContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public FAITHDataInitializer(FAITHContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task InitializeData()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                //seeding the database with recipes, see DBContext
                Wolkenkrabber wolkenkrabber = new Wolkenkrabber();
                _dbContext.Wolkenkrabbers.Add(wolkenkrabber);
                Gebruiker klant1 = new Gebruiker("Anton" , "Engels", "anton.engels.w0190@student.hogent.be","België", "Affligem", "Brusselbaan", "45", wolkenkrabber);
                Gebruiker klant2 = new Gebruiker("Jonas" , "DB", "Jonas2000@live.be","België", "Affligem", "Brusselbaan", "45", wolkenkrabber);
                _dbContext.Gebruikers.Add(klant1);
                _dbContext.Gebruikers.Add(klant2);
                await CreateUser(klant1.Email, "Password123&");
                await CreateAdministrator(klant2.Email, "Password123&");
                _dbContext.SaveChanges();
            }

        }
        private async Task CreateUser(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "klant"));
        }

        private async Task CreateAdministrator(string email, string password)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            await _userManager.CreateAsync(user, password);
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));
            await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "klant"));
        }
    }
}


