using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;

namespace StoreReactSPA.Server.Services.Inteface
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<UserDto> RegisterUserAsync(CreateUserDto createUserDto);
    }
}
