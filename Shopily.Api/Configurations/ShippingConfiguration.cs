using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopily.Api.Models;

namespace Shopily.Api.Configurations
{
    public class ShippingConfiguration : IEntityTypeConfiguration<Shipping>
    {
        public void Configure(EntityTypeBuilder<Shipping> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.OrderId).IsRequired();
            builder.Property(s => s.TrackingNumber).IsRequired();
            builder.Property(s => s.Status).IsRequired().HasMaxLength(50);
            builder.Property(s => s.ShipingDate).IsRequired();

        }
    }
}
