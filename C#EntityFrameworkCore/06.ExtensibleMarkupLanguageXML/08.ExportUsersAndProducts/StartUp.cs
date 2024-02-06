using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();

            //P08.ExportUsersAndProducts
            var output = GetUsersWithProducts(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            return new Mapper(cfg);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            ExportUserWhitAge[] users = context
                                        .Users
                                        .AsNoTracking()
                                        .Where(u => u.ProductsSold.Any())
                                        .OrderByDescending(u => u.ProductsSold.Count)
                                        .Select(u => new ExportUserWhitAge()
                                        {
                                            FirstName = u.FirstName,
                                            LastName = u.LastName,
                                            Age = u.Age,
                                            SoldProducts = new ExportProductsCount()
                                            {
                                                Count = u.ProductsSold.Count,
                                                Products = u.ProductsSold
                                                    .Select(p => new ExportProductNamePrice()
                                                    {
                                                        Name = p.Name,
                                                        Price = p.Price
                                                    })
                                                    .OrderByDescending(p => p.Price)
                                                    .ToArray()
                                            }
                                        })
                                        .ToArray();

            ExportUsersWithCount resultDto = new()
            {
                Count = users.Length,
                Users = users
                    .Take(10)
                    .ToArray()
            };

            return new ParseHelper()
                .Serialize(resultDto, "Users");
        }
    }
}