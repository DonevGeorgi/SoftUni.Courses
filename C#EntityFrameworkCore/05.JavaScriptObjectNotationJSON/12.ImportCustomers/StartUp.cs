using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //P12.ImportCustomers
            var inputJson = File.ReadAllText("../../../Datasets/customers.json");
            var output = ImportCustomers(context, inputJson);

            Console.WriteLine(output);
        }
       
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config); 

            var customerDto = JsonConvert.DeserializeObject<CustomerDTO[]>(inputJson);
            var customers = mapper.Map<Customer[]>(customerDto);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

    }
}