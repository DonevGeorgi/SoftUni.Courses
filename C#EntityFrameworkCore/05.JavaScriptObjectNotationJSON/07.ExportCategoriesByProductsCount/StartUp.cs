using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //P07.ExportCategoriesByProductsCount
            var output = GetCategoriesByProductsCount(context);

            Console.WriteLine(output);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var category = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoriesProducts.Count(),
                    averagePrice = $"{c.CategoriesProducts.Average(p => p.Product.Price):f2}",
                    totalRevenue = $"{c.CategoriesProducts.Count() * c.CategoriesProducts.Average(p => p.Product.Price):f2}"
                })
                .OrderByDescending(c => c.productsCount)
                .ToArray();

            var json = JsonConvert.SerializeObject(category, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return json;    
        }
    }
}