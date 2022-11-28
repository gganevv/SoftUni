namespace _02.Facade
{
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder inCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string addresss)
        {
            Car.Address = addresss;
            return this;
        }
    }
}
