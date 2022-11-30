namespace _03.Template
{
    using System;
    public class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Grain Bread. (15 minutes)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering Ingredients for Whole Wheat Bread.");
        }
    }
}
