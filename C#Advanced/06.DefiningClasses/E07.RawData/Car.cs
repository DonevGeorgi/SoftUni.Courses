using System.Collections.Generic;

namespace DefiningClasses
{
    public class Car
    {
        //Constructor
        public Car(string model,
            int engineSpeed, int enginePower,
            int cargoWeight, string cargoType,
            double tireOnePresure, int tireOneAge,
            double tireTwoPresure, int tireTwoAge,
            double tireThreePresure, int tireThreeAge,
            double tireFourPresure, int tireFourAge)
        {
            Tires = new();

            this.Model = model;
            Engine = new(engineSpeed, enginePower);
            Cargo = new(cargoType, cargoWeight);
            Tires.Add(new(tireOneAge, tireOnePresure));
            Tires.Add(new(tireTwoAge, tireTwoPresure));
            Tires.Add(new(tireThreeAge, tireThreePresure));
            Tires.Add(new(tireFourAge, tireFourPresure));

        }

        //Property
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public List<Tires> Tires { get; set; }

        //Method

    }
}
