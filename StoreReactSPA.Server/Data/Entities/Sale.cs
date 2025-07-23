using StoreReactSPA.Server.Data.Entities.Enums;

namespace StoreReactSPA.Server.Data.Entities
{
    public class Sale
    {
        public int Id { get; set; }

        //  connections
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }



        //Details
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public int DiscountPercentage { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTime SaleDate { get; set; }

        // TODO Payments 
        //public string PaymentMethod { get; set; }
        //public string Status { get; set; }
    }
}
