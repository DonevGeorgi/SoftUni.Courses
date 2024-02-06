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

            //P03.ImportCategories
            var inputXml = File.ReadAllText("../../../Datasets/categories.xml");
            var output =  ImportCategories(context, inputXml);
            
            Console.WriteLine(output);
        }

        private static Mapper GetMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImmportCategoryDTO[]), new XmlRootAttribute("Categories"));

            using var reader = new StringReader(inputXml);

            var immportCategoryDTO = (ImmportCategoryDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var categories = mapper.Map<Category[]>(immportCategoryDTO);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}