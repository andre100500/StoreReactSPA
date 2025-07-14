namespace StoreReactSPA.Server.Models
{
    public class SalesProducModel
    {
        public int Id { get; set; }

        //  connections
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid ProductId { get; set; }
        public ProductModel Product { get; set; }

        //Sales Informatins 
        
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public int Discount { get; set; }
        public decimal DiscountPercent => Discount;
        public decimal DiscountAmount => Math.Round((PricePerUnit * DiscountPercent / 100.0m), 2);
        public decimal FinalPricePerUnit => PricePerUnit - DiscountAmount;
        public decimal TotalPrice => Math.Round(FinalPricePerUnit * Quantity, 2);
        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        // TODO Payments 
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
    }
}
