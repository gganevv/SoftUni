namespace WildFarm.Models
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
        public override string ToString()
            => base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}