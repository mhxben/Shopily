using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopily.Api.Models;

namespace Shopily.Api.Data
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        DbSet<User> Users { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderItems { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Payment> Payments { get; set; }
        DbSet<Shipping> Shippings { get; set; }


        //TODO: Add relationships for models
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
