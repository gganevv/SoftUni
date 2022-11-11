namespace WildFarm.Models
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }
        public override string ToString()
            => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}