using StoreReactSPA.Server.Data.Entities;

namespace StoreReactSPA.Server.Data.Repositories.InterfaceRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> AddAsync(User user);
        Task<User?> GetByEmailAsync(string email);
    }
}
