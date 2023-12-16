namespace P02.VehicleExtension.Models
{
    public class Bus : Vehicle
    {
        private const double increaseFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double litersPerKM, int tankCapacity)
            : base(fuelQuantity, litersPerKM, increaseFuelConsumption, tankCapacity)
        {
        }
    }
}
