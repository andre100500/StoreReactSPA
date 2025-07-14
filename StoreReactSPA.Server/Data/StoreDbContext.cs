using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data
{
    public class StoreDbContext : DbContext 
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
