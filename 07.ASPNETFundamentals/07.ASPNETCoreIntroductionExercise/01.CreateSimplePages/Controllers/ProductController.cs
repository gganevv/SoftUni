using _01.CreateSimplePages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace _01.CreateSimplePages.Controllers
{
    public class ProductController : Controller
    {
        private IEnumerable<ProductViewModel> products
            = new List<ProductViewModel>()
            {
                new ProductViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 7.00
                },
                new ProductViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 5.50
                },
                new ProductViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.50
                }
            };

        public IActionResult All(string keyword)
        {
            if (keyword != null)
            {
                var foundProducts = products
                    .Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
                return View(foundProducts);
            }
            return View(products);
        }

        [Route("/Product/Details/{id?}")]
        public IActionResult ById(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                return View(product);
            }
            else
            {
                return RedirectToAction("All");
            }
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var productsAsText = ConvertToText();

            return Content(productsAsText);
        }

        public IActionResult AllAsTextFile()
        {
            var productsAsText = ConvertToText();

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(productsAsText), "text/plain");
        }

        public string ConvertToText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.AppendLine($"Product {product.Id}: {product.Name} - {product.Price} lv.");
            }

            return sb.ToString();
        }
    }
}
