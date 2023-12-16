namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;

        public Truck(double fuelQuantity, double litersPerKM)
            : base(fuelQuantity, litersPerKM, IncreasedConsumption)
        {
        }

        public override void Refuel(double fuel) => base.Refuel(fuel * 0.95);
    }
}
