using StoreReactSPA.Server.Data.Entities;
using StoreReactSPA.Server.Data.Entities.Enums;

namespace StoreReactSPA.Server.DTOs
{
    public class SaleDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public int DiscountValue { get; set; }
        public DateTime SaleDate { get; set; }

        // Вложенный объект с информацией о продукте
        public ProductInSaleDto Product { get; set; }

        // Вычисляемые поля, как и раньше
        public decimal TotalPrice { get; set; } 
    }
}
