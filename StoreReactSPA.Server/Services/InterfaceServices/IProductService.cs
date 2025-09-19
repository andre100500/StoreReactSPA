using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.DTOs.UpdateDTOs;

namespace StoreReactSPA.Server.Services.Inteface
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(Guid id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(CreateProductDto createDto);
        Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateDto);
        Task DeleteProductAsync(Guid id);
        Task<IEnumerable<Product>> SearchProductsAsync(string? search, string? category);
    }
}
