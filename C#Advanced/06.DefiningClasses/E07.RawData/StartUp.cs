using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
                string[] inputArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Car car = new(inputArgs[0],
                    int.Parse(inputArgs[1]), int.Parse(inputArgs[2]),
                    int.Parse(inputArgs[3]), inputArgs[4],
                    double.Parse(inputArgs[5]), int.Parse(inputArgs[6]),
                    double.Parse(inputArgs[7]), int.Parse(inputArgs[8]),
                    double.Parse(inputArgs[9]), int.Parse(inputArgs[10]),
                    double.Parse(inputArgs[11]), int.Parse(inputArgs[12]));

                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "fragile" && car.Tires.Any(x => x.Pressure < 1))
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
            else
            {
                foreach (var car in cars)
                {
                    if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }
}