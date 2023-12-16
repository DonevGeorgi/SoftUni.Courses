using P02.VehicleExtension.Models.Interfaces;

namespace P02.VehicleExtension.Factory.Interfaces
{
    public interface IFactory
    {
        IVehicle Create(string type, double fuelAmount, double literPerKM, int tankCapacity);
    }
}
