namespace StoreReactSPA.Server.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int DiscountValue { get; set; }
        public string TitleProduct => $"{Category}:{Name}";

        public decimal FinalPrice { get
            {
                if (DiscountValue > 0)
                {
                    var discountAmount = Price * DiscountValue / 100.0m;
                    return Price - discountAmount;
                }
                return Price;
            } 
        }
    }
}
