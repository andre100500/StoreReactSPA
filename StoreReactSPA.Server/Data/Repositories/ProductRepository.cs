using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;

namespace StoreReactSPA.Server.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _dbContext;

        public ProductRepository (StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product> AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();    
            return product;
        }

        public async Task DeleteAsync(Guid id)
        {
            var productToDelete = await _dbContext.Products.FindAsync(id);
            if (productToDelete != null) 
            {
                _dbContext.Products.Remove(productToDelete);
                await _dbContext.SaveChangesAsync();   
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
           _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return product;
        }
    }
}
