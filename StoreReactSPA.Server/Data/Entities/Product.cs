namespace StoreReactSPA.Server.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; }
        public string TitleProduct => $"{Category}:{Name}";

        public string Category { get; set; } = string.Empty;
    }
}
