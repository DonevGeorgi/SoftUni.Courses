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

            //P13.ImportSales
            var input = File.ReadAllText("../../../Datasets/sales.xml");
            var output = ImportSales(context, input);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSalesDTO[]), new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);

            var importSaleDTO = xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var salesDto = mapper.Map<ImportSalesDTO[]>(importSaleDTO);

            List<Sale> sales = new();

            int[] carIds = context.Cars
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();

            foreach (ImportSalesDTO currSale in salesDto)
            {
                if (carIds.Contains(currSale.CarId))
                {
                    Sale sale = mapper.Map<Sale>(currSale);
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
    }
}