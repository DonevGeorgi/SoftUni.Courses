namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ExportDto;
    using Trucks.Extensions;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder result = new();


            ExportDespatchersDTO[] despatcherDtos = XmlSerializationHelper.Deserialize<ExportDespatchersDTO[]>(xmlString, "Despatchers");

            List<Despatcher> despatchers = new();

            foreach (var currDespatcher in despatcherDtos)
            {
                if (!IsValid(currDespatcher))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher newDespatcher = new()
                {
                    Name = currDespatcher.Name,
                    Position = currDespatcher.Position
                };

                foreach (var currTruck in currDespatcher.DispatcherTrucks)
                {
                    if (!IsValid(currTruck))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    newDespatcher.Trucks.Add(new Truck()
                    {
                        RegistrationNumber = currTruck.RegistrationNumber,
                        VinNumber = currTruck.VinNumber,
                        TankCapacity = currTruck.TankCapacity,
                        CargoCapacity = currTruck.CargoCapacity,
                        CategoryType = (CategoryType)currTruck.CategoryType,
                        MakeType = (MakeType)currTruck.MakeType
                    });
                }

                despatchers.Add(newDespatcher);
                result.AppendLine(string.Format(SuccessfullyImportedDespatcher, newDespatcher.Name, newDespatcher.Trucks.Count()));
            }

            Console.WriteLine(result.ToString().TrimEnd());
            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var result = new StringBuilder();

            ExportClientDto[] clientsJson = JsonConvert.DeserializeObject<ExportClientDto[]>(jsonString);

            var clients = new List<Client>();

            foreach (var currClient in clientsJson)
            {
                if (!IsValid(currClient))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var newClient = new Client() 
                { 
                    Name = currClient.Name,
                    Nationality = currClient.Nationality,
                    Type = currClient.Type
                };

                if (newClient.Type == "usual")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var truckId in currClient.Trucks.Distinct())
                {
                    var currTruck = context.Trucks.Find(truckId);

                    if(currTruck == null)
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    newClient.ClientsTrucks.Add(new ClientTruck()
                    {
                        Truck = currTruck
                    });
                }

                clients.Add(newClient);
                result.AppendLine(String.Format(SuccessfullyImportedClient,newClient.Name,newClient.ClientsTrucks.Count()));
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}