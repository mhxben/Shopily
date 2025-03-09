using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopily.Api.Models;

namespace Shopily.Api.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.OrderId).IsRequired();
            builder.Property(p => p.PaymentDate).IsRequired();
            builder.Property(p => p.PaymentMethod).IsRequired();
            builder.Property(p => p.PaymentStatus).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Amount).IsRequired();
        }
    }
}
