using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(CreateProductDto createDto);
        Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateDto);
        Task DeleteProductAsync(Guid id);
    }
}
