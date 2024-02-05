using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;
using System.Runtime.CompilerServices;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //P08.ExportUsersAndProducts
            var output = GetUsersWithProducts(context);

            Console.WriteLine(output);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                        .Where(u => u.ProductsSold.Any(x => x.BuyerId != null))
                        .Select(u => new
                        {

                            firstName = u.FirstName,
                            lastName = u.LastName,
                            age = u.Age,
                            soldProducts = u.ProductsSold
                                              .Where(b => b.BuyerId != null)
                                              .Select(p => new
                                              {
                                                  name = p.Name,
                                                  price = p.Price
                                              })
                                              .ToList()
                        })
                        .OrderByDescending(u => u.soldProducts.Count())
                        .ToList();

            var usersJson = JsonConvert.SerializeObject(new
            {
                usersCount = users.Count(),
                users = users
                .Select(u => new
                {
                    u.firstName,
                    u.lastName,
                    u.age,
                    soldProducts = new
                    {
                        count = u.soldProducts.Count(),
                        products = u.soldProducts
                    }
                })
            }, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });

            return usersJson;
        }
    }
}