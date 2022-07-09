namespace _07.VehicleCatalogue
{
    public class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HoresePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HoresePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HoresePower}hp";
        }
    }
}
