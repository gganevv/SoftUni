namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        public const double CAR_CONSUMPTION_INCREMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption + CAR_CONSUMPTION_INCREMENT)
        {
        }
    }
}
