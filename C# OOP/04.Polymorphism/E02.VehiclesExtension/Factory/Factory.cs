using P02.VehicleExtension.Factory.Interfaces;
using P02.VehicleExtension.Models;
using P02.VehicleExtension.Models.Interfaces;

namespace P02.VehicleExtension.Factory
{
    public class Factory : IFactory
    {
        public IVehicle Create(string type, double fuelAmount, double literPerKM, int tankCapacity)
        {
            IVehicle newVehicle = null;

            if (type == "Car")
            {
                IVehicle curVehicle = new Car(fuelAmount, literPerKM, tankCapacity);

                newVehicle = curVehicle;
            }
            else if (type == "Truck")
            {
                IVehicle curVehicle = new Truck(fuelAmount, literPerKM, tankCapacity);

                newVehicle = curVehicle;
            }
            else if (type == "Bus")
            {
                IVehicle currVehicle = new Bus(fuelAmount, literPerKM, tankCapacity);

                newVehicle = currVehicle;
            }

            return newVehicle;
        }
    }
}
