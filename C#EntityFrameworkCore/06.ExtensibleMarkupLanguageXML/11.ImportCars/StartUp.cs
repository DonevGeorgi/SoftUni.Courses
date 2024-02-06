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

            //P11.ImportCars
            var input = File.ReadAllText("../../../Datasets/cars.xml");
            var output = ImportCars(context, input);

            Console.WriteLine(output);
        }

        private static Mapper GetMapper()
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCarsDTO[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);

            var importCarsDTO = xmlSerializer.Deserialize(reader);

            var mapper = GetMapper();
            ImportCarsDTO[] carsDto = mapper.Map<ImportCarsDTO[]>(importCarsDTO);

            List<Car> cars = new();

            var partsIds = context.Parts
                .Select(p => p.Id)
                .ToList();

            foreach (var currCar in carsDto)
            {
                Car newCar = mapper.Map<Car>(currCar);

                foreach (var part in currCar.Parts.DistinctBy(parts => parts.PartyId))
                {
                    if (partsIds.Contains(part.PartyId))
                    {
                        newCar.PartsCars.Add(new PartCar
                        {
                            PartId = part.PartyId
                        });
                    }
                }

                cars.Add(newCar);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }
    }
}