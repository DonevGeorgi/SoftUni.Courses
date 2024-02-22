using Homies.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventParticipants>()
                .HasKey(ep => new { ep.HelperId, ep.EventId });

            modelBuilder.Entity<EventParticipants>()
                .HasOne(e => e.Event)
                .WithMany(e => e.EventParticipants)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Models.Type>()
                .HasData(new Models.Type()
                {
                    Id = 1,
                    Name = "Animals"
                },
                new Models.Type()
                {
                    Id = 2,
                    Name = "Fun"
                },
                new Models.Type()
                {
                    Id = 3,
                    Name = "Discussion"
                },
                new Models.Type()
                {
                    Id = 4,
                    Name = "Work"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventParticipants> EventsParticipants { get; set; }
        public DbSet<Models.Type> Types { get; set; }
    }
}