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

            //P07.ExportCategoryByProductsCount
            var output = GetCategoriesByProductsCount(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = new StringBuilder();

            var mapper = GetMapper();

            var categories = context.Categories
                .ProjectTo<ExportCategoryByProductsCount>(mapper.ConfigurationProvider)
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCategoryByProductsCount[]), new XmlRootAttribute("Categories"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty,string.Empty);

            using (var sw = new StringWriter(result))
            {
                xmlSerializer.Serialize(sw, categories, xsn);
            }

            return result.ToString().TrimEnd();
        }
    }
}