using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Entities.Enums;
using StoreReactSPA.Server.Data.Repositories;
using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _serviceRepository;
        //TODO Realization product repository for take amount price add ect 
        private readonly IProductRepository _productRepository;
        public SaleService(ISaleRepository serviceRepository, IProductRepository productRepository)
        {
            _serviceRepository = serviceRepository;
            _productRepository = productRepository;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto, Guid userId)
        {// 1. Проверяем входные данные
            if (createSaleDto.Quantity <= 0)
            {
                throw new ArgumentException("Ammount equal > 0", nameof(createSaleDto.Quantity));
            }

            var product = await _productRepository.GetByIdAsync(createSaleDto.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {createSaleDto.ProductId} is not found.");
            }

            // if (product.Stock < createSaleDto.Quantity) { ... }

            var saleEntity = new Sale
            {
                ProductId = product.Id,
                UserId = userId,
                Quantity = createSaleDto.Quantity,
                PricePerUnit = product.Price, 
                SaleDate = DateTime.UtcNow,
                DiscountType = DiscountType.None,
                DiscountValue = 0
            };

            //  if (user.HasDiscountCard) { saleEntity.DiscountType = ... }

            var newSale = await _saleRepository.AddAsync(saleEntity);
            newSale.Product = product; 

            return MapSaleToDto(newSale);
        }

        public async Task<SaleDto> GetSaleByIdAsync(int id)
        {
            var saleEntity = await _saleRepository.GetByIdAsync(id);
            if (saleEntity == null)
            {
                throw new KeyNotFoundException($"Продажа с ID {id} не найдена.");
            }

            // Используем тот же маппер
            return MapSaleToDto(saleEntity);
        }

       
        private SaleDto MapSaleToDto(Sale sale)
        {
            var totalPrice = sale.PricePerUnit * sale.Quantity;
           

            return new SaleDto
            {
                Id = sale.Id,
                Quantity = sale.Quantity,
                PricePerUnit = sale.PricePerUnit,
                DiscountValue = sale.DiscountValue,
                SaleDate = sale.SaleDate,
                TotalPrice = totalPrice,
                Product = new ProductInSaleDto
                {
                    Id = sale.Product.Id,
                    Name = sale.Product.Name
                }
            };      
        }
    }
}
