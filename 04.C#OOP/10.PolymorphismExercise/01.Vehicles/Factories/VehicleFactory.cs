namespace Vehicles.Factories
{
    using Interfaces;
    using Models;
    using Models.Interfaces;
    public class VehicleFactory : IVehicleFactory
    {

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new System.Exception();
            }

            return vehicle;
        }
    }
}
