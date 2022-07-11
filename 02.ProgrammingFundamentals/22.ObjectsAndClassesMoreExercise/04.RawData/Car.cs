namespace _04.RawData
{
    public class Car
    {
        public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType)
        {
            Model = model;
            Engine engine = new Engine(engineSpeed, enginePower);
            Engine = engine;
            Cargo cargo = new Cargo(cargoWeight, cargoType);
            Cargo = cargo;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }

    }
}
