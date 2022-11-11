using System;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        private const double MOUSE_WEIGHT_MODIFIER = 0.1;
        public override void Feed(Food.Food food)
        {
            if (food is null || (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit"))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            else
            {
                Weight += food.Quantity * MOUSE_WEIGHT_MODIFIER;
                FoodEaten += food.Quantity;
            }
        }

        public override string ProduceSound()
            => "Squeak";
        public override string ToString()
            => $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}