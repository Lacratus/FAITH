using FAITHAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAITHAPI.Data
{
    public class FAITHContext : IdentityDbContext
    {
        public FAITHContext(DbContextOptions<FAITHContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Gebruiker>().HasKey(k => k.Id);
            builder.Entity<Gebruiker>().Property(k => k.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Gebruiker>().Property(k => k.LastName).IsRequired().HasMaxLength(50);
            
            builder.Entity<Gebruiker>().Property(k => k.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Gebruiker>().Property(k => k.Country).IsRequired().HasMaxLength(200);
            builder.Entity<Gebruiker>().Property(k => k.City).IsRequired().HasMaxLength(200);
            builder.Entity<Gebruiker>().Property(k => k.Street).IsRequired().HasMaxLength(200);
            builder.Entity<Gebruiker>().Property(k => k.StreetNr).IsRequired().HasMaxLength(200);
            builder.Entity<Gebruiker>()
                .HasMany(b => b.Posts)
                .WithOne();

            builder.Entity<Gebruiker>().HasKey(b => b.Id);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Verdieping> Verdiepingen {get;set;}
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Wolkenkrabber> Wolkenkrabbers { get; set; }
    }

}
