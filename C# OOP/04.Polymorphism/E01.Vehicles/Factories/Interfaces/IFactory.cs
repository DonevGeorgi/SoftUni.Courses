using P01.Vehicles.Models.Interfaces;

namespace P01.Vehicles.Factories.Interface
{
    public interface IFactory
    {
        IVehicle Create(string type, double fuelQuantity, double fuelConsumption);
    }
}
