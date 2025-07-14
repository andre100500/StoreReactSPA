using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Repositories;
using StoreReactSPA.Server.DTOs;

namespace StoreReactSPA.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

            return new UserDto 
            { 
                Id = newUser.Id,
                Email = newUser.Email,
                Name = newUser.Name
            };
        }
    }
}
