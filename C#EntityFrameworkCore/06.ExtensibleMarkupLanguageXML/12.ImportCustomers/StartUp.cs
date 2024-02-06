using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //P12.ImportCustomers
            var input = File.ReadAllText("../../../Datasets/customers.xml");
            var output = ImportCustomers(context, input);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDTO[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);

            var importCustomerDTO = xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var customers = mapper.Map<Customer[]>(importCustomerDTO);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }
    }
}