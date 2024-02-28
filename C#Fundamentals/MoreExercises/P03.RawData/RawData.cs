using System;
using System.Collections.Generic;

namespace P03.RawData
{
    internal class RawData
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            ClassesInitializations(cars);

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car item in cars)
                {
                    if (item.CargoWeight < 1000 && item.CargoType == "fragile")
                    {
                        Console.WriteLine(item.Model);
                    }
                }
            }
            else if (command == "flamable")
            {
                foreach (Car engine in cars)
                {
                    if (engine.EnginePower > 250 && engine.CargoType == "flamable")
                    {
                        Console.WriteLine(engine.Model);
                    }
                }
            }
        }

        private static void ClassesInitializations(List<Car> cars)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];

                Car car = new Car(model,engineSpeed,enginePower, cargoWeight, cargoType);
                cars.Add(car);
            }
        }
    }

    class Cargo
    {
        public Cargo(string model,int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
    class Engine : Cargo
    {
        public Engine(string model,int engineSpeed, int enginePower,int cargoWeight, string cargoType)
            :base(model,cargoWeight, cargoType)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
    class Car : Engine
    {
        public Car(string model, int engineSpeed, int enginePower,int cargoWeight, string cargoType)
            :base(model,engineSpeed, enginePower,cargoWeight, cargoType)
        {
            this.Model = model;
        }

        public string Model { get; set; }
    }

}
