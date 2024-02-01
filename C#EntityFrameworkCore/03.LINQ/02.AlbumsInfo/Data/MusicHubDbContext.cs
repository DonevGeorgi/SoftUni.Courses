﻿using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Performer> Performsers { get; set; }
        public DbSet<SongPerformer> SongPerformers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Producer> Producers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>()
                   .HasKey(sp => new {sp.SongId, sp.PerformerId});
        }
    }
}
