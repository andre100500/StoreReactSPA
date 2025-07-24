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
            var productEntity = await _dbContext.Products.FindAsync(id);
            if (productEntity != null) 
            {
                _dbContext.Products.Remove(productEntity);
                await _dbContext.SaveChangesAsync();   
            }
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var existingProduct  = await _dbContext.Products.FindAsync(product.Id);
            if (existingProduct == null) 
            {
                return null;
            }
            product.Id = existingProduct.Id;
            product.Name = existingProduct.Name;
            product.Description = existingProduct.Description;
            product.Category = existingProduct.Category;

            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
