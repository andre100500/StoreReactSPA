using StoreReactSPA.Server.Data.Entities.Enums;

namespace StoreReactSPA.Server.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; }
     
        public decimal Price { get; set; }
        public DiscountType DiscountType { get; set; }
        public int DiscountValue { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}
