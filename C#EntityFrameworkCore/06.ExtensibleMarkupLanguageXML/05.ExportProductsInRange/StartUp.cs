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

            //P05.ExportProductsInRange
            var output = GetProductsInRange(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var mapper = GetMapper();

             var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ProjectTo<ExportProducttInRange>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportProducttInRange[]), new XmlRootAttribute("Products"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var stringBuilder = new StringBuilder();

            using (var sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, products, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}