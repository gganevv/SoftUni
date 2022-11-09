namespace Vehicles.Models
{
    using Vehicles.Models;
    public class Truck : Vehicle
    {
        public const double TRUCK_CONSUMPTION_INCREMENT = 1.6;
        private const double TRUCK_REFUELING_COEFFICIENT = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + TRUCK_CONSUMPTION_INCREMENT)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters * TRUCK_REFUELING_COEFFICIENT);
        }
    }
}
