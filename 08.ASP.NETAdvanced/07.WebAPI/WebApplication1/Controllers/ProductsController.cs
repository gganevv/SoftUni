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

        /// <summary>
        /// Gets a list with all products.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     GET /api/products
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with a list of all products</response>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return this.productService.GetAllProducts();
        }

        /// <summary>
        /// Gets a product by id.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     GET /api/products/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with the product</response>
        /// <response code="404">Returns "Not Found" when the given product doesn't exist.</response>
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

        /// <summary>
        /// Creates a product.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     POST /api/products
        ///     {
        ///         "name": "Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="201">Returns "Created" with the created product</response>
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            product = this.productService
                .CreateProduct(product.Name, product.Description);

            return CreatedAtAction("GetProduct", product);
        }

        /// <summary>
        /// Edits a product.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     PUT /api/products/{id}
        ///     {
        ///         "name": "New Candy",
        ///         "description": "Chocolate"
        ///     }
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="404">Returns "Not Found" when product with the given id desn't exist</response>
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

        /// <summary>
        /// Edits a product partially.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     PUT /api/products/{id}
        ///     {
        ///         "name": "New Candy"
        ///     }
        /// </remarks>
        /// <response code="204">Returns "No Content"</response>
        /// <response code="404">Returns "Not Found" when product with the given id desn't exist</response>
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

        /// <summary>
        /// Deletes a product.
        /// </summary>
        /// <remarks>
        /// Simple request:
        /// 
        ///     DELETE /api/products/{id}
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <response code="200">Returns "OK" with the deleted product</response>
        /// <response code="404">Returns "Not Found" when product with the given id desn't exist</response>
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
