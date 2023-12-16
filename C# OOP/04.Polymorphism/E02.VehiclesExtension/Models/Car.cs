namespace P02.VehicleExtension.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKM, int tankCapacity)
            : base(fuelQuantity, litersPerKM, IncreasedConsumption, tankCapacity)
        {
        }
    }
}
