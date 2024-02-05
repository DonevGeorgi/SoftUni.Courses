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

            //P13.ImportSales
            var inputJson = File.ReadAllText("../../../Datasets/sales.json");
            var output = ImportSales(context,inputJson);

            Console.WriteLine(output);
        }
        
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            var saleDto = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);
            var sales = mapper.Map<Sale[]>(saleDto);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

    }
}