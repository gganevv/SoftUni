using System;

namespace WildFarm.Models
{
    public class Hen : Bird
    {
        private const double HEN_WEIGHT_MODIFIER = 0.35;

        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override void Feed(Food.Food food)
        {
            if (food is null)
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * HEN_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "Cluck";
    }
}