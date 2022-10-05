using System.Text;

namespace _08.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"  {this.Engine.Model}:");
            stringBuilder.AppendLine($"    Power: {this.Engine.Power}");
            if (this.Engine.Displacement > 0)
            {
                stringBuilder.AppendLine($"    Displacement: {this.Engine.Displacement}");
            }
            else
            {
                stringBuilder.AppendLine($"    Displacement: n/a");
            }
            if (this.Engine.Efficiency != null)
            {
                stringBuilder.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }
            else
            {
                stringBuilder.AppendLine($"    Efficiency: n/a");
            }
            if (this.Weight > 0)
            {
                stringBuilder.AppendLine($"  Weight: {this.Weight}");
            }
            else
            {
                stringBuilder.AppendLine($"  Weight: n/a");
            }
            if (this.Color != null)
            {
                stringBuilder.AppendLine($"  Color: {this.Color}");
            }
            else
            {
                stringBuilder.AppendLine($"  Color: n/a");
            }
            
            return stringBuilder.ToString().Trim();
        }
    }
}