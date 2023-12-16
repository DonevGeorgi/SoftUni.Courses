using P01.Vehicles.Models.Interfaces;

namespace P01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increaseFuelConsumption;

        public Vehicle(double fuelQuantity, double litersPerKM, double increaseFuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            LitersPerKM = litersPerKM;
            this.increaseFuelConsumption = increaseFuelConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double LitersPerKM { get; private set; }

        public string Drive(double distance)
        {
            double consumption = increaseFuelConsumption + LitersPerKM;

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel) => FuelQuantity += fuel;

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}
