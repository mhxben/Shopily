﻿namespace Shopily.Api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public Product ProductId { get; set; }
        public User UserId { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
