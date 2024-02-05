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

            //P06.ExportSoldProducts
            var output = GetSoldProducts(context);

            Console.WriteLine(output);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var user = context.Users
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                                  .Where(p => p.Buyer != null)
                                  .Select(b => new
                                  {
                                      name = b.Name,
                                      price = b.Price,
                                      buyerFirstName = b.Buyer.FirstName,
                                      buyerLastName = b.Buyer.LastName
                                  })
                                  .OrderBy(b => b.buyerLastName)
                                  .ThenBy(b => b.buyerFirstName)
                                  .ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            var json = JsonConvert.SerializeObject(user, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}