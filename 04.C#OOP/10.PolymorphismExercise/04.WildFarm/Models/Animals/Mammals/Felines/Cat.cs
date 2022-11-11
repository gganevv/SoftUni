using System;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        private const double CAT_WEIGHT_MODIFIER = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override void Feed(Food.Food food)
        {
            if (food is null || (food.GetType().Name != "Meat" && food.GetType().Name != "Vegetable"))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * CAT_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "Meow";
    }
}