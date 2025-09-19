using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories.InterfaceRepositories
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);    
        Task<Product> UpdateAsync(Product product); 
        Task DeleteAsync (Guid id);
        Task<IEnumerable<Product>> SearchAsync(string? search, string? category);
    }
}
