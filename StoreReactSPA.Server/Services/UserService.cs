using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.DTOs.UpdateDTOs;
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

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users =  await _userManager.Users.ToListAsync();
            return  users.Select(MapUserToDto);
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user == null)
            {
                throw new KeyNotFoundException($"User with ID '{id}' not found.");
            }
            if(!string.IsNullOrEmpty(updateUserDto.UserName))
                user.UserName = updateUserDto.UserName;
            if(!string.IsNullOrEmpty(updateUserDto.Email))
                user.Email = updateUserDto.Email;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            return MapUserToDto(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) 
            { 
               return false;
            }
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
