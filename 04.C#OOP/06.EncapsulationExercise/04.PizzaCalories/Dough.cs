namespace _04.PizzaCalories
{
    using System;
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
        }

        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        private string BakingTechnique
        {
            set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        private double Weight
        {
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public double CaloriesPerGram => GetCaloriesPerGram();
        public double TotalCalories => GetCaloriesPerGram() * weight;
        private double GetCaloriesPerGram()
        {
            double calories = 2;
            if (flourType.ToLower() == "white") calories *= 1.5;
            if (bakingTechnique.ToLower() == "crispy") calories *= 0.9;
            else if (bakingTechnique.ToLower() == "chewy") calories *= 1.1;

            return calories;
        }
    }
}
