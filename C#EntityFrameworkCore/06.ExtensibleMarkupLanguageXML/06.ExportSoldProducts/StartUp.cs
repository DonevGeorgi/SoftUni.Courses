using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //P06.ExportSoldProducts
            var output = GetSoldProducts(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = new StringBuilder();

            var mapper = GetMapper();

            var products = context.Users
                .Where(p => p.ProductsSold.Any())
                .OrderBy(n => n.LastName)
                .ThenBy(n => n.FirstName)
                .Take(5)
                 .Select(u => new ExportedSoldProducts
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     SoldProducts = u.ProductsSold.Select(p => new ExportProductNamePrice()
                     {
                         Name = p.Name,
                         Price = p.Price,
                     })
                .ToArray()
                 })
                .ProjectTo<ExportedSoldProducts>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportedSoldProducts[]), new XmlRootAttribute("Users"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            using (var sw = new StringWriter(result))
            {
                xmlSerializer.Serialize(sw, products, xsn);
            }

            return result.ToString().TrimEnd();
        }
    }
}