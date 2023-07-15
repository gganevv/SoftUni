using ProductsApi.Data;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext data;

        public ProductService(ProductDbContext data)
            => this.data = data;
    }
}
