namespace NeedForSpeed
{
    public class SportCar : Car
    {
        private const double SPORT_CAR_DEFAULT_FUEL_CONSUMPTION = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => SPORT_CAR_DEFAULT_FUEL_CONSUMPTION;
    }
}
