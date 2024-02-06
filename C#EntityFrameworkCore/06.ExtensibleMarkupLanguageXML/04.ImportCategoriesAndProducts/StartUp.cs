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

            //P04.ImportCategoriesAndProducts
            var inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            var output = ImportCategoryProducts(context, inputXml);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoriesProductsDTO[]), new XmlRootAttribute("CategoryProducts"));

            using var reader = new StringReader(inputXml);

            var importCategoriesProductsDTO = (ImportCategoriesProductsDTO[])xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var categoryProducts = mapper.Map<CategoryProduct[]>(importCategoriesProductsDTO);
            var filteredCategoryProducts = categoryProducts.Where(x => x.ProductId != null && x.CategoryId != null).ToArray();

            if (filteredCategoryProducts.Any())
            {
                context.CategoryProducts.AddRange(filteredCategoryProducts);
                context.SaveChanges();

                return $"Successfully imported {categoryProducts.Length}";
            }

            return $"Successfully imported 0";
        }
    }
}