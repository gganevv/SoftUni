using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext
            (DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; init; }
    }
}
