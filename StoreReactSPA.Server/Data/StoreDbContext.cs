using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data
{
    public class StoreDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

    }
}
