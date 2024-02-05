using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new CarDealerContext();

            //P11.ImportCars
            var inputJson = File.ReadAllText("../../../Datasets/cars.json");
            var output = ImportCars(context, inputJson);

            Console.WriteLine(output);
        }

        private static IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            CarDTO[] carDtos = Newtonsoft.Json.JsonConvert.DeserializeObject<CarDTO[]>(inputJson)!;

            List<Car> cars = new();

            foreach (var carDto in carDtos)
            {
                Car car = mapper.Map<Car>(carDto);

                foreach (int partId in carDto.PartsId.Distinct())
                {
                    car.PartsCars.Add(new PartCar()
                    {
                        PartId = partId
                    });
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }
    }
}