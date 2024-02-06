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

            //P02.ImportProducts
            var inputXml = File.ReadAllText("../../../Datasets/products.xml");
            var output = ImportProducts(context, inputXml);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImmportProductDTO[]), new XmlRootAttribute("Products"));

            using StringReader reader = new StringReader(inputXml);

            var immportProductDTO = (ImmportProductDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var products = mapper.Map<Product[]>(immportProductDTO);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}