namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const double InitialFuelAvailable = 65;
        private const double InitialFuelConsumption = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower)
            : base(make, model, VIN, horsePower, InitialFuelAvailable, InitialFuelConsumption)
        {
        }
    }
}
