namespace StoreReactSPA.Server.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string EmailConfirmed { get; set; }= string.Empty;
        public string PasswordConfirmed { get; set; } = string.Empty;

        public ProductModel Product { get; set; }
    }
}
