namespace Shopily.Api.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchaseTime { get; set; }
        public decimal Subtotal { get; set; }
    }
}
