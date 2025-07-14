namespace StoreReactSPA.Server.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string NameProduct { get; set; } = string.Empty; 
        public string DescriptionProduct { get; set; }
        public string TitleProduct => $"{Category}:{NameProduct}";

        public string Category { get; set; } = string.Empty;
    }
}
