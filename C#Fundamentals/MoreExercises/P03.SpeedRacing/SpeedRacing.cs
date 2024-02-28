using System;
using System.Collections.Generic;

namespace P03.SpeedRacing
{
    internal class SpeedRacing
    {
        static void Main()
        {
            List<Car> cars = new List<Car>();

            CarsInitialization(cars);
            CarMovementsOperations(cars);

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmound:f2} {car.TravelDistance}");
            }
        }

        private static void CarMovementsOperations(List<Car> cars)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = commandArgs[1];
                decimal amountOfKM = decimal.Parse(commandArgs[2]);

                int index = cars.FindIndex(car => car.Model == model);
                cars[index].CarMovement(amountOfKM);
            }
        }

        static void CarsInitialization(List<Car> cars)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                decimal fuelAmount = decimal.Parse(input[1]);
                decimal fuelConsumptionForKM = decimal.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionForKM, 0);
                cars.Add(car);
            }
        }
    }

    class Car
    {
        public Car(string model, decimal fuelAmount, decimal fuelConsumptionRate, decimal travelDistance)
        {
            this.Model = model;
            this.FuelAmound = fuelAmount;
            this.FuelConsumptionRatePerKM = fuelConsumptionRate;
            this.TravelDistance = travelDistance;
        }

        public string Model { get; set; }
        public decimal FuelAmound { get; set; }
        public decimal FuelConsumptionRatePerKM { get; set; }
        public decimal TravelDistance { get; set; }


        public void CarMovement(decimal km)
        {
            if (this.FuelAmound < (this.FuelConsumptionRatePerKM * km))
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.TravelDistance += km;

            this.FuelAmound -= this.FuelConsumptionRatePerKM * km;
        }
    }
}
