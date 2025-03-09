namespace Shopily.Api.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
