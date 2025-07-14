using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(CreateUserDto createUserDto);
    }
}
