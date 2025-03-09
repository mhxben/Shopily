using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopily.Api.Models;

namespace Shopily.Api.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => od.Id);
            builder.Property(od => od.OrderId).IsRequired();
            builder.Property(od => od.ProductId).IsRequired();
            builder.Property(od => od.Quantity).IsRequired();
            builder.Property(od => od.PriceAtPurchaseTime).IsRequired();
            builder.Property(od => od.Subtotal).IsRequired();

        }
    }
}
