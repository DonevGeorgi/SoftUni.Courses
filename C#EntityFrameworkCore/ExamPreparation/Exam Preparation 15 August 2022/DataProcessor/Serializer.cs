namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Extensions;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Any())
                .ToArray()
                .Select(d => new ImportDespatchersDto(){

                    Name = d.Name,
                    TruckCount = d.Trucks.Count(),
                    Trucks = d.Trucks
                    .Select(t => new ImportTrucksDto()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        Make = t.MakeType.ToString()
                    })
                    .OrderBy(t => t.RegistrationNumber)
                    .ToArray()  
                })
                .OrderByDescending(d => d.TruckCount)
                .ThenBy(d => d.Name)
                .ToArray();

            return XmlSerializationHelper.Serialize(despatchers, "Despatchers");
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    c.Name,
                    Trucks = c.ClientsTrucks
                            .Where(t => t.Truck.TankCapacity >= capacity)
                            .ToArray()
                            .OrderBy(t => t.Truck.MakeType.ToString())
                            .ThenByDescending(t => t.Truck.CargoCapacity)
                            .Select(t => new
                            {
                                TruckRegistrationNumber = t.Truck.RegistrationNumber,
                                VinNumber = t.Truck.VinNumber,
                                TankCapacity = t.Truck.TankCapacity,
                                CargoCapacity = t.Truck.CargoCapacity,
                                CategoryType = t.Truck.CategoryType.ToString(),
                                MakeType = t.Truck.MakeType.ToString(),
                            })
                            .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10) 
                .ToArray();

            return JsonConvert.SerializeObject(clients, Formatting.Indented);
        }
    }
}
