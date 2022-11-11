using System;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        private const double TIGER_WEIGHT_MODIFIER = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
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
                Weight += food.Quantity * TIGER_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "ROAR!!!";
    }
}