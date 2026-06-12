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
    }
}