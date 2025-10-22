using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.DTOs.UpdateDTOs;

namespace StoreReactSPA.Server.Services.Inteface
{
    public interface IUserService
    {
        Task<UserDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto);
        Task<UserDto> RegisterUserAsync(CreateUserDto createUserDto);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
