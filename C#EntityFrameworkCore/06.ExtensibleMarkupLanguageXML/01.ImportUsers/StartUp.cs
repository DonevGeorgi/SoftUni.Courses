using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //P01.ImportUsers
            var inputXml = File.ReadAllText("../../../Datasets/users.xml");
            var output = ImportUsers(context,inputXml);


            Console.WriteLine(output);
        }

        private static Mapper GetMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            //1.Create xml serializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImmportUserDTO[]), new XmlRootAttribute("Users"));

            //2.Deserializing whit stream of the data
            using var reader = new StringReader(inputXml);

            ImmportUserDTO[] immportUserDTOs = (ImmportUserDTO[])xmlSerializer.Deserialize(reader);

            //3.Mapping this data to the object
            var mapper = GetMapper();
            User[] users = mapper.Map<User[]>(immportUserDTOs);
            
            //4.Add to EF context
            context.Users.AddRange(users);

            //5.Commint changes to DB
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}