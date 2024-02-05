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

            //P05.ExportProductsInRange
            var output = GetProductsInRange(context);

            Console.WriteLine(output);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price,
                                seller = p.Seller.FirstName + " " + p.Seller.LastName
                            })
                            .Where(p => p.price >= 500 && p.price <= 1000)
                            .OrderBy(p => p.price)
                            .ToArray();

            var productsJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return productsJson;
        }
    }
}