using Microsoft.AspNetCore.Identity;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.Services.Inteface;

namespace StoreReactSPA.Server.Services
{
    public class UserService : IUserService
    {

        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var userEntity = await _userManager.FindByIdAsync(id.ToString());

            if (userEntity == null) 
            {
                throw new KeyNotFoundException($"The user with ID {id} was not found.");
            }
            var userDto = new UserDto{
                Id = userEntity.Id,
                Name = userEntity.UserName,
                Email = userEntity.Email
            };

            return userDto;
        }

        private UserDto MapUserToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email
            };
        }
        public async Task<UserDto> RegisterUserAsync(CreateUserDto createUserDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(createUserDto.Email);
            if (existingUser != null) 
            { 
                throw new Exception("This is Email no avaible");
            }
            object passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

            var userEntity = new User
            {
                UserName = createUserDto.Name,
                Email = createUserDto.Email,
            };
            var newUser = await _userManager.CreateAsync(userEntity, createUserDto.Password);

            if (!newUser.Succeeded)
            {
                throw new Exception(string.Join(", ", newUser.Errors.Select(e => e.Description)));
            }

            return MapUserToDto(userEntity);
        }
    }
}
