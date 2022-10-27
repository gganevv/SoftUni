namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        private const double MOTORCYCLE_DEFAULT_CONSUMPTION = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => MOTORCYCLE_DEFAULT_CONSUMPTION;
    }
}
