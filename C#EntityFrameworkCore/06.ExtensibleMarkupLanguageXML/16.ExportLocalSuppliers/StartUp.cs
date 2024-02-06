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

            //P16.ExportLocalSuppliers
            var output = GetLocalSuppliers(context);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }
       
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var mapper = GetMapper();

            var supplier = context.Suppliers
                .Where(s => s.IsImporter == false)
                .ProjectTo<ExportLocalSuppliers>(mapper.ConfigurationProvider)
                .ToArray();

            var xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliers[]), new XmlRootAttribute("suppliers"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(string.Empty, string.Empty);

            var stringBuilder = new StringBuilder();

            using (var sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, supplier, xsn);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}