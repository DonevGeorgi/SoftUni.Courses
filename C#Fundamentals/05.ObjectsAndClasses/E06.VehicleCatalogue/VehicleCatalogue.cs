using System;
using System.Collections.Generic;
using System.Linq;

namespace E06.VehicleCatalogue
{
    internal class VehicleCatalogue
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            List<Truck> trucks = new List<Truck>();

            int countOfTrucks = 0;
            int countOfCars = 0;
            double totalSumOfCarsHP = 0;
            double totalSumOfTruckHP = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string typeOfVehicle = inputArgs[0];
                string modelOfVehicle = inputArgs[1];
                string colorOfVehicle = inputArgs[2];
                int horsePowerOfVehicle = int.Parse(inputArgs[3]);

                if (typeOfVehicle == "car")
                {
                    countOfCars++;
                    totalSumOfCarsHP += horsePowerOfVehicle;

                    Car car = new Car("Car", modelOfVehicle, colorOfVehicle, horsePowerOfVehicle);
                    cars.Add(car);
                }
                else if (typeOfVehicle == "truck")
                {
                    countOfTrucks++;
                    totalSumOfTruckHP += horsePowerOfVehicle;

                    Truck truck = new Truck("Truck", modelOfVehicle, colorOfVehicle, horsePowerOfVehicle);
                    trucks.Add(truck);
                }

            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                foreach (Car car in cars)
                {
                    if (command == car.Model)
                    {
                        Console.WriteLine($"Type: {car.Type}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Color: {car.Color}");
                        Console.WriteLine($"Horsepower: {car.HorsePower}");
                    }
                }

                foreach (Truck truck in trucks)
                {
                    if (command == truck.Model)
                    {
                        Console.WriteLine($"Type: {truck.Type}");
                        Console.WriteLine($"Model: {truck.Model}");
                        Console.WriteLine($"Color: {truck.Color}");
                        Console.WriteLine($"Horsepower: {truck.HorsePower}");
                    }
                }
            }

            if (cars.Count > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {(totalSumOfCarsHP / countOfCars):f2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:f2}.");
            }

            if (trucks.Count > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {(totalSumOfTruckHP / countOfTrucks):f2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:f2}.");
            }
        }

        public class Car
        {
            public Car(string type, string model, string color, int horsePower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }

        public class Truck
        {
            public Truck(string type, string models, string color, int horsePower)
            {
                this.Type = type;
                this.Model = models;
                this.Color = color;
                this.HorsePower = horsePower;
            }

            public string Type { get; set; }
            public string Model { get; set; }
            public string Color { get; set; }
            public int HorsePower { get; set; }
        }
    }
}
