using P01.Vehicles.Core.Interfaces;
using P01.Vehicles.Factories.Interface;
using P01.Vehicles.IO.Reader.Interface;
using P01.Vehicles.IO.Writer.Interface;
using P01.Vehicles.Models.Interfaces;

namespace P01.Vehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        public readonly IReader reader;
        private readonly IFactory factory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IWriter consoleWtiter, IReader consoleReader, IFactory factory)
        {
            this.writer = consoleWtiter;
            this.reader = consoleReader;
            this.factory = factory;

            this.vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            vehicles.Add(CreatingCar());
            vehicles.Add(CreatingTruck());

            ProcessingCommands();
        }

        private void ProcessingCommands()
        {
            int commandsCount = int.Parse(reader.ReaderLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] currCommand = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = currCommand[0];
                string vehicleType = currCommand[1];

                IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

                try
                {
                    if (command == "Drive")
                    {
                        double distance = double.Parse(currCommand[2]);
                        writer.WriteLine(vehicle.Drive(distance));
                    }
                    else if (command == "Refuel")
                    {
                        double fuelAmount = double.Parse(currCommand[2]);
                        vehicle.Refuel(fuelAmount);
                    }
                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            foreach (var currVehicle in vehicles)
            {
                writer.WriteLine(currVehicle.ToString());
            }
        }

        private IVehicle CreatingCar()
        {
            string[] carArgs = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = carArgs[0];
            double fuelQuantity = double.Parse(carArgs[1]);
            double litersPerKM = double.Parse(carArgs[2]);

            return factory.Create(type, fuelQuantity, litersPerKM);
        }
        private IVehicle CreatingTruck()
        {
            string[] truckArgs = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = truckArgs[0];
            double fuelQuantity = double.Parse(truckArgs[1]);
            double litersPerKM = double.Parse(truckArgs[2]);

            return factory.Create(type, fuelQuantity, litersPerKM);
        }
    }
}
