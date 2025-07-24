using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Entities.Enums;
using StoreReactSPA.Server.Data.Repositories;
using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDto> CreateProductAsync(CreateProductDto createDto)
        {
            var productEntity = new Product
            {
                Name = createDto.Name,
                Category = createDto.Category,
                Description = createDto.Description,
                DiscountType = DiscountType.None,
                DiscountValue = 0,
                Price  = createDto.Price
            };
            var newProduct  = await _productRepository.AddAsync(productEntity);
            return MapProductToDto(newProduct);
        }

        private ProductDto MapProductToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                DiscountValue= product.DiscountValue,
                Price = product.Price
            };
        }

        public async Task DeleteProductAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => MapProductToDto(p));
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                throw new KeyNotFoundException($"Product is Id {id} not Found.");
            }
            return MapProductToDto(product);
        }

        public async Task<ProductDto> UpdateProductAsync(Guid id, UpdateProductDto updateDto)
        {
            var existingProduct  = await _productRepository.GetByIdAsync(id); 
            if (existingProduct == null)
            { 
                throw new KeyNotFoundException($"Product is Id {id} not Found.");
            }
            existingProduct.Name = updateDto.Name;
            existingProduct.Description = updateDto.Description;
            existingProduct.Category = updateDto.Category;
            existingProduct.Price = updateDto.Price;
            existingProduct.DiscountValue = updateDto.DiscountValue;
            existingProduct.DiscountType = updateDto.DiscountValue > 0 ? DiscountType.Percentage : DiscountType.None;

            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            return MapProductToDto(updatedProduct);
        }
    }
}
