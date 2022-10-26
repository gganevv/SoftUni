namespace Restaurant
{
    public class Fish : MainDish
    {
        public Fish(string name, decimal price, double grams) : base(name, price, grams)
        {
        }

        public Fish(string name, decimal price) : this(name, price, 0)
        {

        }

        public override double Grams => 22;
    }
}
