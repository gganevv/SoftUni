namespace WildFarm.Models
{
    using WildFarm.Models.Food;
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract string ProduceSound();
        public abstract void Feed(Food.Food food);

        public override string ToString()
            => $"{this.GetType().Name} [{Name}, ";

    }
}