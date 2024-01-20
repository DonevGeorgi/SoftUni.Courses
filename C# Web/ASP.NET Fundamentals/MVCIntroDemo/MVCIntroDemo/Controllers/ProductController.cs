using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using MVCIntroDemo.Models.Products;
using System.Text;
using System.Text.Json;

namespace MVCIntroDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private IEnumerable<ProductViewModel> _products = new List<ProductViewModel>()
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

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string keyword)
        {
            if (keyword != null)
            {
                var searchResult = _products.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));

                return View(searchResult);
            }

            return View(_products);
        }

        [ActionName("ById")]
        public IActionResult ProductById(int id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                TempData["ErrorMessage"] = "There is no such product!";
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            return Json(_products, options);
        }

        public IActionResult AllAsText()
        {
            var productsAsText = new StringBuilder();

            foreach (var currItem in _products)
            {
                productsAsText.AppendLine($"Product {currItem.Id}: {currItem.Name} - {currItem.Price:f2} lv.");
            }

            return Content(productsAsText.ToString());
        }

        public IActionResult AllAsTextFile()
        {
            var productsAsText = new StringBuilder();

            foreach (var currItem in _products)
            {
                productsAsText.AppendLine($"Product {currItem.Id}: {currItem.Name} - {currItem.Price:f2} lv.");
            }

            Response.Headers.Add(HeaderNames.ContentDisposition, @"attachmment;filename=products.txt");

            return File(Encoding.UTF8.GetBytes(productsAsText.ToString()),"text/plain");
        }
    }
}
