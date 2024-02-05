using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            var output = GetOrderedCustomers(context);

            Console.WriteLine(output);
        }
      
        public static string GetOrderedCustomers(CarDealerContext context) 
        {
            var customer = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    IsYoungDriver = c.IsYoungDriver,
                })
                .ToArray();

            var customerJson = JsonConvert.SerializeObject(customer, Formatting.Indented);
            return customerJson;
        }
    }
}