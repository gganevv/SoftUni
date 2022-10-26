namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name, decimal price, double grams, double calories) : base(name, price, grams, calories)
        {
        }

        public Cake(string name)
            : this(name, 0, 0, 0)
        {

        }

        public override double Grams => 250;
        public override double Calories => 1000;
        public override decimal Price => 5;
    }
}
