using Moq;
using FluentAssertions;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.Services;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
namespace StoreReactSPA.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productService = new ProductService(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct_WhenProductExists()
        {
            var productId = Guid.NewGuid();
            var productEntity = new Product { Id = productId, Name = "Test Product", Price = 100 };

            _productRepositoryMock
                .Setup(repo => repo.GetByIdAsync(productId))
                .ReturnsAsync(productEntity);

            var result = await _productService.GetProductByIdAsync(productId);
            result.Should().NotBeNull();
            result.Should().BeOfType<Product>();
            result.Id.Should().Be(productId);
            result.Name.Should().Be(result.Name);

        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldThrowException_WhenProductDoesNotExist()
        {
            var nonExistentId = Guid.NewGuid();

            _productRepositoryMock
                .Setup(repo=> repo.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Product)null);

            await _productService.Awaiting(service => service.GetProductByIdAsync(nonExistentId))
                .Should().ThrowAsync<KeyNotFoundException>();
        }

        [Fact]
        public async Task CreateProductAsync_ShouldReturnNewProductDto_AndCallRepository()
        {
            var createDto = new CreateProductDto { Name = "New ", Price =100, Category = "Meat" , Description = "Description" };
            var prodctId = Guid.NewGuid();

            _productRepositoryMock
                .Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                .ReturnsAsync((Product p) =>
                {
                    p.Id = prodctId;
                    return p;
                });

            var result = await _productService.CreateProductAsync(createDto);
            
            result.Should().NotBeNull();
            result.Id.Should().Be(prodctId);
            result.Name.Should().Be(createDto.Name);

            _productRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Product>()),Times.Once());

        }
    }
}
