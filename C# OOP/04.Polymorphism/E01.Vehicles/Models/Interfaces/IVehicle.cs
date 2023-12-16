namespace P01.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double LitersPerKM { get; }
        string Drive(double distance);
        void Refuel(double fuel);
    }
}
