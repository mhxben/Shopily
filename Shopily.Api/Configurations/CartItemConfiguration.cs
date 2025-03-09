using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopily.Api.Models;

namespace Shopily.Api.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.CartId).IsRequired();
            builder.Property(ci => ci.ProductId).IsRequired();
            builder.Property(ci => ci.Quantity).IsRequired();


        }
    }
}
