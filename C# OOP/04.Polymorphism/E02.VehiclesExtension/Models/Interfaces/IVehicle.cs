namespace P02.VehicleExtension.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double LitersPerKM { get; }
        int TankCapacity { get; }
        string Drive(double distance, bool isTherePeople);
        void Refuel(double fuel);
    }
}
