namespace NeedForSpeed
{
    public class Car : Motorcycle
    {
        private const double defaultFuelConsumption = 3;
        protected Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }

        public override double FuelConsumption => defaultFuelConsumption;
    }
}
