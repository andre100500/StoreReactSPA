using Microsoft.AspNetCore.Mvc;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Entities.Enums;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.DTOs.UpdateDTOs;
using StoreReactSPA.Server.Services.Inteface;

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
            if(id == Guid.Empty) 
            {  
                throw new ArgumentException("Product ID cannot be empty"); 
            }


            var product = await _productRepository.GetByIdAsync(id);
            if(product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found");
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
            existingProduct.Price = (decimal)updateDto.Price;
            existingProduct.DiscountValue = (int)updateDto.DiscountValue;
            existingProduct.DiscountType = updateDto.DiscountValue > 0 ? DiscountType.Percentage : DiscountType.None;

            var updatedProduct = await _productRepository.UpdateAsync(existingProduct);
            return MapProductToDto(updatedProduct);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string? search, string? category)
        {
           var products = await _productRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(search))
            {
                products = products
                    .Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrWhiteSpace(category))
            {
                products = products
                    .Where(p => p.Category.Contains(category, StringComparison.OrdinalIgnoreCase));
            }
            return products;
        }
    }
}
