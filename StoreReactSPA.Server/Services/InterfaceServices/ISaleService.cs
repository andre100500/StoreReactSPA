using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;

namespace StoreReactSPA.Server.Services.Inteface
{
    public interface ISaleService
    {
        Task<SaleDto> GetSaleDetailsAsync(int id);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto, Guid userId);
    }
}
