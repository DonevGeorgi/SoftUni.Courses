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

            var userJson = File.ReadAllText(@"../../../Datasets/users.json");
            var output = ImportUsers(context, userJson);

            Console.WriteLine(output);

        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}