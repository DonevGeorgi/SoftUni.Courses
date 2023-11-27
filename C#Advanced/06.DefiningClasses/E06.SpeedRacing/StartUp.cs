using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!cars.Any(x => x.Model == carsData[0]))
                {
                    Car car = new(carsData[0], double.Parse(carsData[1]), double.Parse(carsData[2]));

                    cars.Add(car);
                }
            }

            string commands = string.Empty;

            while ((commands = Console.ReadLine()) != "End")
            {
                string[] commandsArgs = commands
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandsArgs[0] == "Drive")
                {
                    foreach (var car in cars)
                    {
                        if (car.Model == commandsArgs[1])
                        {
                            car.Move(commandsArgs[1], double.Parse(commandsArgs[2]));
                        }
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}