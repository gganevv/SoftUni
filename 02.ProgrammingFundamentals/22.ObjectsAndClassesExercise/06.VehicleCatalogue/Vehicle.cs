using System.Globalization;
using System.Text;

namespace _06.VehicleCatalogue
{
    public class Vehicle
    {
        public Vehicle(string type, string model, string color, double horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Type)}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().Trim();
        }
    }
}
