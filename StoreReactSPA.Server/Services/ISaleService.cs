using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public interface ISaleService
    {
        Task<SaleDto> GetSaleDetailsAsync(int id);
        Task<SaleDto> CreateSaleAsync(CreateSaleDto createSaleDto, Guid userId);
    }
}
