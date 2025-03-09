namespace Shopily.Api.Models
{
    public class Shipping
    {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public DateTime ShipingDate { get; set; }

    }
}
