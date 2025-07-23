using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;

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

        public async Task<Sale> GetByIdAsync(int id)
        {
            return await _dbContext.Sales.FindAsync(id);
        }
   
    }
}
