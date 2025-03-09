using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopily.Api.Models;

namespace Shopily.Api.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.UserId).IsRequired();
            builder.Property(o => o.TotalPrice).IsRequired();
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(o => o.Status).IsRequired().HasMaxLength(100);
            builder.Property(o => o.TotalPrice).IsRequired();
        }
    }
}
