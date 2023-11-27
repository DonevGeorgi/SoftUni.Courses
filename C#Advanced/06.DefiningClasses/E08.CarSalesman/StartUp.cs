using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new();
            List<Engine> engines = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new(engineData[0], int.Parse(engineData[1]));

                if (engineData.Length == 4)
                {
                    engine.Displacement = int.Parse(engineData[2]);
                    engine.Efficiency = engineData[3];
                }
                else if (engineData.Length == 3)
                {
                    int displayecement;

                    bool isTrue = int.TryParse(engineData[2], out displayecement);

                    if (isTrue)
                    {
                        engine.Displacement = displayecement;
                    }
                    else
                    {
                        engine.Efficiency = engineData[2];
                    }
                }


                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Engine engine = engines.Find(x => x.Model == carData[1]);

                Car car = new(carData[0], engine);

                if (carData.Length == 4)
                {
                    car.Weight = int.Parse(carData[2]);
                    car.Color = carData[3];
                }
                else if (carData.Length == 3)
                {
                    int weight;

                    bool isTrue = int.TryParse(carData[2], out weight);

                    if (isTrue)
                    {
                        car.Weight = weight;
                    }
                    else
                    {
                        car.Color = carData[2];
                    }
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}