using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);    
        Task<Product> UpdateAsync(Product product); 
        Task DeleteAsync (Guid id); 
    }
}
