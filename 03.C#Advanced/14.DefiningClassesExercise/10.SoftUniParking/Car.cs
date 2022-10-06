namespace SoftUniParking
{
    public class Car
    {
        private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registrationNumber;
        }

        public string Make { get { return make; } set { this.make = value; } }
        public string Model { get { return model; } set { this.model = value; } }
        public int HorsePower { get { return horsePower; } set { horsePower = value; } }
        public string RegistrationNumber { get { return registrationNumber; } set { registrationNumber = value; } }

        public override string ToString()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nHorsePower: {this.HorsePower}\nRegistrationNumber: {this.RegistrationNumber}";
        }
    }
}
