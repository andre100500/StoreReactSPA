using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;

namespace StoreReactSPA.Server.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly StoreDbContext _dbContext;
        public SaleRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            await _dbContext.Sales.AddAsync(sale);
            await _dbContext.SaveChangesAsync();
            return sale;
        }

        public Task<Sale> DeleteSaleAsync(Sale sale)
        {
            throw new NotImplementedException();
        }

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _dbContext.Sales
                .Include(s=> s.Product)
                .FirstOrDefaultAsync(s=> s.Id == id);
        }

        public Task<Sale> UpdateSaleAsync(Sale sale)
        {
            throw new NotImplementedException();
        }
    }
}
