using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Entities.Enums;

namespace StoreReactSPA.Server.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public int DiscountPercentage { get; set; }

        public decimal DiscountAmount => Math.Round((PricePerUnit * DiscountPercentage / 100.0m), 2);

        public decimal FinalPricePerUnit => PricePerUnit - DiscountAmount;
        public decimal TotalPrice => Math.Round(FinalPricePerUnit * Quantity, 2);
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
