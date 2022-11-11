using System;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        private const double DOG_WEIGHT_MODIFIER = 0.4;
        public override void Feed(Food.Food food)
        {
            if (food is null || food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * DOG_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "Woof!";
        public override string ToString()
            => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}