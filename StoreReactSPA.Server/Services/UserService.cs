using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories.InterfaceRepositories;
using StoreReactSPA.Server.DTOs;
using StoreReactSPA.Server.DTOs.CreatedDTOs;
using StoreReactSPA.Server.Services.Inteface;

namespace StoreReactSPA.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);

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

        public UserDto MapUserToDto(User user)
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
            var existingUser = await _userRepository.GetByEmailAsync(createUserDto.Email);
            if (existingUser != null) 
            { 
                throw new Exception("This is Email no avaible");
            }
            object passwordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);

            var userEntity = new User
            {
                UserName = createUserDto.Name,
                Email = createUserDto.Email,
                PasswordHash = (string)passwordHash
            };
            var newUser = await _userRepository.AddAsync(userEntity);

            return MapUserToDto(newUser);
        }
    }
}
