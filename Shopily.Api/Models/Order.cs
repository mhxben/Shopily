namespace Shopily.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        
    }
}
