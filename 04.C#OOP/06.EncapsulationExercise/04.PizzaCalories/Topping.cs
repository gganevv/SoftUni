namespace _04.PizzaCalories
{
    using System;
    public class Topping
    {
        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        private string Type
        {
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{type} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }

        public double CaloriesPerGram => GetCaloriesPerGram();

        private double GetCaloriesPerGram()
        {
            double calories = 2;
            switch (type.ToLower())
            {
                case "meat": calories *= 1.2; break;
                case "veggies": calories *= 0.8; break;
                case "cheese": calories *= 1.1; break;
                case "sauce": calories *= 0.9; break;
            }

            return calories;
        }

        public double TotalCalories => GetCaloriesPerGram() * weight;
    }
}
