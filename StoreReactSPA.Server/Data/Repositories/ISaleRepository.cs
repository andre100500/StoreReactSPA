using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(int id);
        Task<Sale> AddSaleAsync(Sale sale);
    }
}
