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

            //P14.ExportCarsWithDistance
            var output = GetCarsWithDistance(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var mapper = GetMapper();

            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarsWhitDistance>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportCarsWhitDistance[]), new XmlRootAttribute("cars"));

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