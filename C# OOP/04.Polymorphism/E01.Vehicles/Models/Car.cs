namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double IncreasedConsumption = 0.9;

        public Car(double fuelQuantity, double litersPerKM)
            : base(fuelQuantity, litersPerKM, IncreasedConsumption)
        {
        }
    }
}
