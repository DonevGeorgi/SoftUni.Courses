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

            //E17.ExportCarsWithTheirListOfParts
            var output = GetCarsWithTheirListOfParts(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var mapper = GetMapper();

            var cars = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarsWhitParts>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsWhitParts[]), new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var stringBuilder = new StringBuilder();

            using (var sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, cars, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}