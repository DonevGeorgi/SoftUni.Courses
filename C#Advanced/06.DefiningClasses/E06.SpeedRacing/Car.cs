namespace DefiningClasses
{
    public class Car
    {
        //Constructors
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

        //Properties
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        //Methods
        public void Move(string carModel, double amountOfKm)
        {
            double distanceToMove = this.FuelConsumptionPerKilometer * amountOfKm;

            if (this.FuelAmount >= distanceToMove)
            {
                this.FuelAmount -= distanceToMove;
                this.TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
