using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories.InterfaceRepositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> AddSaleAsync(Sale sale);
        Task<Sale> UpdateSaleAsync(Sale sale);
        Task<Sale> DeleteSaleAsync(Sale sale);
    }
}
