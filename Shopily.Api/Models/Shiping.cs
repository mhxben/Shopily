namespace Shopily.Api.Models
{
    public class Shiping
    {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public string trackingNumber { get; set; }
        public string status { get; set; }
        public DateTime ShipingDate { get; set; }

    }
}
