namespace _07.VehicleCatalogue
{
    public class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }
}
