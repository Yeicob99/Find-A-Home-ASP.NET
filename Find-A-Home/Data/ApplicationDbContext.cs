using Microsoft.EntityFrameworkCore;
using Find_A_Home.Models;

namespace Find_A_Home.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Zone> Zones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Province>().HasData(
                new Province
                {
                    Id = 1,
                    Name = "Distrito Nacional",
                },
                new Province
                {
                    Id = 2,
                    Name = "Santo Domingo",
                },
                new Province
                {
                    Id = 3,
                    Name = "Santiago",
                }

            );
            modelBuilder.Entity<Zone>().HasData(
                new Zone
                {
                    Id = 1,
                    Name = "Naco",
                    ProvinceId = 1,
                },
                new Zone
                {
                    Id = 2,
                    Name = "Piantini",
                    ProvinceId = 1,
                }
                );
        }
    }
}