using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //E18.ExportTotalSalesByCustomer
            var output = GetTotalSalesByCustomer(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var mapper = GetMapper();

            var customersWithSales = context.Customers
            .Include(c => c.Sales)
            .Where(c => c.Sales.Any())
            .ToArray();

            var customers = customersWithSales
                .Select(c => new ExportTotalSalesBuCustomer()
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Join(
                            context.Parts,
                            pc => pc.PartId,
                            p => p.Id,
                            (pc, p) => c.IsYoungDriver
                                ? ((decimal)Math.Round((double)pc.Part.Price * 0.95, 2))
                                : pc.Part.Price
                        )
                        .Sum()
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerialize = new(typeof(ExportTotalSalesBuCustomer[]), new XmlRootAttribute("customers"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var stringBuilder = new StringBuilder();

            using (var sw = new StringWriter(stringBuilder))
            {
                xmlSerialize.Serialize(sw, customers, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}