using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Models;

namespace StoreReactSPA.Server.Data
{
    public class StoreDbContext : DbContext 
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<SalesProducModel> salesProducModels { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public StoreDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
