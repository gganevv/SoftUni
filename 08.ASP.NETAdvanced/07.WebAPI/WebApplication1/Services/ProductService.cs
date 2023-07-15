using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext data;

        public ProductService(ProductDbContext data)
            => this.data = data;

        public Product CreateProduct(string name, string description)
        {
            var product = new Product
            {
                Name = name,
                Description = description
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return product;
        }

        public Product DeleteProduct(int id)
        {
            var product = this.data.Products.Find(id);

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return product;
        }

        public void EditProduct(int id, Product product)
        {
            var dbProduct = this.data.Products.Find(id);

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;

            this.data.SaveChanges();
        }

        public void EditProductPartially(int id, Product product)
        {
            var dbProduct = this.data.Products.Find(id);

            dbProduct.Name = string.IsNullOrEmpty(product.Name) ? dbProduct.Name : product.Name;
            dbProduct.Description = string.IsNullOrEmpty(product.Description) ? dbProduct.Description : product.Description;

            this.data.SaveChanges();
        }

        public List<Product> GetAllProducts()
            => this.data.Products.ToList();

        public Product GetById(int id)
            => this.data.Products.Find(id);
    }
}
