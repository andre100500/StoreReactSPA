namespace StoreReactSPA.Server.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }

        public ICollection<Sales> SalesProduc { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
