using Microsoft.EntityFrameworkCore;
using Models;

namespace TP4
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}
