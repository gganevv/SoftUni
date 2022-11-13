namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double CONSUMPTION_INCREASE = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        { }

        public override string Drive(double km)
        {
            FuelConsumption += CONSUMPTION_INCREASE;
            string drive = base.Drive(km);
            base.FuelConsumption -= CONSUMPTION_INCREASE;
            return drive;
        }

        public string DriveEmpty(double distance)
        {
            return base.Drive(distance);
        }
    }
}