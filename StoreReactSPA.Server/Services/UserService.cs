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
        public UserDto MapUserToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
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
                Name = createUserDto.Name,
                Email = createUserDto.Email,
                PasswordHash = (string)passwordHash
            };
            var newUser = await _userRepository.AddAsync(userEntity);

            return MapUserToDto(newUser);
        }
    }
}
