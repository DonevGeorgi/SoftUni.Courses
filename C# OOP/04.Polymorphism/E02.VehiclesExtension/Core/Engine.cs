using P02.VehicleExtension.Core.Interfaces;
using P02.VehicleExtension.Factory.Interfaces;
using P02.VehicleExtension.Models.Interfaces;
using P02.VehiclesExtension.IO.Reader.Interface;
using P02.VehiclesExtension.IO.Writer.Interface;

namespace P02.VehicleExtension.Core
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
            vehicles.Add(CreatingBus());

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
                        writer.WriteLine(vehicle.Drive(distance, true));
                    }
                    else if (command == "DriveEmpty")
                    {
                        double distance = double.Parse(currCommand[2]);
                        writer.WriteLine(vehicle.Drive(distance, false));
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
            int tankCapacity = int.Parse(carArgs[3]);

            return factory.Create(type, fuelQuantity, litersPerKM, tankCapacity);
        }
        private IVehicle CreatingTruck()
        {
            string[] truckArgs = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = truckArgs[0];
            double fuelQuantity = double.Parse(truckArgs[1]);
            double litersPerKM = double.Parse(truckArgs[2]);
            int tankCapacity = int.Parse(truckArgs[3]);

            return factory.Create(type, fuelQuantity, litersPerKM, tankCapacity);
        }
        private IVehicle CreatingBus()
        {
            string[] carArgs = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string type = carArgs[0];
            double fuelQuantity = double.Parse(carArgs[1]);
            double litersPerKM = double.Parse(carArgs[2]);
            int tankCapacity = int.Parse(carArgs[3]);

            return factory.Create(type, fuelQuantity, litersPerKM, tankCapacity);
        }
    }
}
