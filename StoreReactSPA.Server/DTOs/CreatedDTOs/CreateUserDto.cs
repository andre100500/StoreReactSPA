namespace StoreReactSPA.Server.DTOs.CreatedDTOs
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
