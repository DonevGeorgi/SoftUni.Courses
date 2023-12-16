using P01.Vehicles.Factories.Interface;
using P01.Vehicles.Models;
using P01.Vehicles.Models.Interfaces;

namespace P01.Vehicles.Factories
{
    public class Factory : IFactory
    {
        public IVehicle Create(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle newVehicle = null;

            if (type == "Car")
            {
                IVehicle curVehicle = new Car(fuelQuantity, fuelConsumption);

                newVehicle = curVehicle;
            }
            else if (type == "Truck")
            {
                IVehicle curVehicle = new Truck(fuelQuantity, fuelConsumption);

                newVehicle = curVehicle;
            }

            return newVehicle;
        }
    }
}
