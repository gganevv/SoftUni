using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    internal partial class Program
    {
        public class Demon
        {
            public Demon(string name)
            {
                Name = name;
                Health = CalculateHealth(name);
                Damage = CalculateDamage(name);
            }

            public int CalculateHealth(string name)
            {
                string healthPattern = @"[^\+\-\*\/\.,0-9]";
                int sum = 0;
                var healthChar = Regex.Matches(name, healthPattern);
                foreach (Match match in healthChar)
                {
                    sum += char.Parse(match.Value);
                }
                return sum;
            }
            public double CalculateDamage(string name)
            {
                double sum = 0;
                string digitsPattern = @"-?\d+\.?\d*";
                string multiplyDividePattern = @"[\*\/]";
                var digits = Regex.Matches(name, digitsPattern);
                var multiplyDivide = Regex.Matches(name, multiplyDividePattern);
                foreach (Match match in digits)
                {
                    sum += double.Parse(match.Value);
                }
                foreach (Match match in multiplyDivide)
                {
                    if (match.Value == "*")
                    {
                        sum *= 2;
                    }
                    else
                    {
                        sum /= 2;
                    }
                }
                return sum;
            }

            public string Name { get; set; }
            public int Health { get; set; }
            public double Damage { get; set; }

            public override string ToString()
            {
                return $"{Name} - {Health} health, {Damage:f2} damage";
            }
        }
    }
}
