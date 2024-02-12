namespace Trucks.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Trucks.Data.Models;

    public class TrucksContext : DbContext
    {
        public TrucksContext()
        { 
        }

        public TrucksContext(DbContextOptions options)
            : base(options) 
        { 
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<ClientTruck> ClientsTrucks { get; set; }
        public DbSet<Despatcher> Despatchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTruck>().HasKey(ct => new { ct.ClientId, ct.TruckId})
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
