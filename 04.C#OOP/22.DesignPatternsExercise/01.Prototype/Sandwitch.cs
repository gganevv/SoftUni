namespace _01.Prototype
{
    using System;
    public class Sandwitch : SandwichPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwitch(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }
        public override SandwichPrototype Clone()
        {
            Console.WriteLine($"Cloning sandwich with ingredients: {this.GetIngredients()}");
            return MemberwiseClone() as SandwichPrototype;
        }

        private string GetIngredients()
            => $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
    }
}
