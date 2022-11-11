using System;

namespace WildFarm.Models
{
    public class Owl : Bird
    {
        private const double OWL_WEIGHT_MODIFIER = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is null || food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * OWL_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "Hoot Hoot";
    }
}