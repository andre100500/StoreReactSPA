using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;

namespace StoreReactSPA.Server.Services.Inteface
{
    public interface IUserService
    {
        Task<UserDto> RegisterUserAsync(CreateUserDto createUserDto);
    }
}
