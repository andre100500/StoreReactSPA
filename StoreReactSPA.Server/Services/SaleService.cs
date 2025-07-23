using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories;
using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _serviceRepository;
        public SaleService(ISaleRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto)
        {
            var saleEntitty = new Sale
            {
                Name = createSaleDto.Name,
                Description = createSaleDto.Description,
                Category = createSaleDto.Category
            };
            var newSale = await _serviceRepository.AddSaleAsync(saleEntitty);
            return new SaleDto 
            {
                Id = newSale.Id,
                Name = newSale.Name,
                Description = newSale.Description,
                Category = newSale.Category
            };
        }

        public async Task<SaleDto> GetSaleDetailsAsync(int id)
        {
            var saleEntity = await _serviceRepository.GetByIdAsync(id);
            if (saleEntity == null) 
            {
                throw new Exception($"Sale with ID {id} was not found.");
            }

            var saleDto = new SaleDto
            {
                Id = saleEntity.Id,
                Quantity = saleEntity.Quantity,
                DiscountPercentage = saleEntity.DiscountPercentage,
                PricePerUnit = saleEntity.PricePerUnit,
                Description = saleEntity.Description,
                Category = saleEntity.Category
            };
            return saleDto;
        }
    }
}
