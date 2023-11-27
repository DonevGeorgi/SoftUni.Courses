using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Parking
    {
        //Fields
        private Dictionary<string, Car> cars;

        private int capacity;


        //Constructor
        public Parking(int capacity)
        {
            cars = new();

            this.capacity = capacity;
        }

        //Properties

        public int Count { get { return this.cars.Count; } }

        //Methods

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (cars.Count == capacity)
            {
                return "Parking is full!";

            }

            cars.Add(car.RegistrationNumber, car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registration)
        {
            if (!cars.ContainsKey(registration))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registration);
            return $"Successfully removed {registration}";
        }
        public Car GetCar(string registration)
        {
            return cars[registration];
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrations)
        {
            foreach (var registration in registrations)
            {
                RemoveCar(registration);
            }
        }
    }
}
