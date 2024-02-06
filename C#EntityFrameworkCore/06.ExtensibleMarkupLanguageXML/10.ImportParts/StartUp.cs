using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
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

            //P10.ImportParts
            var input = File.ReadAllText("../../../Datasets/parts.xml");
            var output = ImportParts(context, input);


            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartsDTO[]), new XmlRootAttribute("Parts"));

            using var reader = new StringReader(inputXml);

            var importPartsDto = xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            var partsFromDTO = mapper.Map<Part[]>(importPartsDto);

            var suppliersIds = context.Suppliers
                                      .Select(p => p.Id)
                                      .ToList();

            List<Part> parts = new();

            foreach(var currPart in partsFromDTO)
            {
                if (suppliersIds.Contains(currPart.SupplierId))
                {
                    Part newPart = mapper.Map<Part>(currPart);
                    parts.Add(newPart);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
    }
}