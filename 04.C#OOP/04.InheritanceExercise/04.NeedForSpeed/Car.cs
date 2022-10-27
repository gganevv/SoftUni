namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double CAR_DEFAULT_CONSUMPTION = 3;
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
        }

        public override double DefaultFuelConsumption => CAR_DEFAULT_CONSUMPTION;
    }
}
