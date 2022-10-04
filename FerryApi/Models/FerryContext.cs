using Microsoft.EntityFrameworkCore;


namespace FerryApi.Models
{
    public class FerryContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "FerryDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasKey(c => new { c.LicensePlateId });
        }

        public DbSet<Parking> ParkingSpots { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
