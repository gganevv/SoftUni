using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
            => this.productService = productService;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return this.productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = this.productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            product = this.productService
                .CreateProduct(product.Name, product.Description);

            return CreatedAtAction("GetProduct", product);
        }

        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            this.productService.EditProduct(id, product);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchProduct(int id, Product product)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }


            this.productService.EditProductPartially(id, product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            if (this.productService.GetById(id) == null)
            {
                return NotFound();
            }

            var product = this.productService.DeleteProduct(id);

            return product;
        }
    }
}
