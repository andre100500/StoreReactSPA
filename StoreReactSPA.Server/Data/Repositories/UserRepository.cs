using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _dbContext;
        public UserRepository(StoreDbContext context) 
        {
            _dbContext = context;
        }
        public async Task<User> AddAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);  
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FindAsync(id);
        }
    }
}
