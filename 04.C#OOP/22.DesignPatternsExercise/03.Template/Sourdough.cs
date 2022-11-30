namespace _03.Template
{
    using System;
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread.");
        }
    }
}
