using P02.VehicleExtension.Models.Interfaces;

namespace P02.VehicleExtension.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increaseFuelConsumption;

        private double fuelQuantity;

        public Vehicle(double fuelQuantity, double litersPerKM, double increaseFuelConsumption, int tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            LitersPerKM = litersPerKM;
            this.increaseFuelConsumption = increaseFuelConsumption;
        }

        public double FuelQuantity
        {

            get => fuelQuantity;

            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;

                }
            }
        }

        public double LitersPerKM { get; private set; }

        public int TankCapacity { get; private set; }

        public virtual string Drive(double distance, bool isTherePeople)
        {
            double consumption = 0;

            if (isTherePeople)
            {
                consumption += LitersPerKM + increaseFuelConsumption;
            }
            else
            {
                consumption = LitersPerKM;
            }

            if (FuelQuantity < distance * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * consumption;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + fuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }


            FuelQuantity += fuel;
        }

        public override string ToString() => $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}
