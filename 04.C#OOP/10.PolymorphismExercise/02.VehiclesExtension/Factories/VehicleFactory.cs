namespace Vehicles.Factories
{
    using Vehicles.Factories.Interfaces;
    using Vehicles.Models.Interfaces;

    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (type)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    return null;
            }
        }
    }
}
