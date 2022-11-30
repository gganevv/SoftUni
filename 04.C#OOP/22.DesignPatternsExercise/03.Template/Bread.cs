namespace _03.Template
{
    using System;
    public abstract class Bread
    {
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
        public abstract void MixIngredients();
        public abstract void Bake();
        public virtual void Slice()
        {
            Console.WriteLine("Slicing the " + GetType().Name + " bread!");
        }
    }
}
