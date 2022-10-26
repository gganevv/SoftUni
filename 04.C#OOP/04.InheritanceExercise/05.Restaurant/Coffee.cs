namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine, decimal price, double milliliters) : base(name, price, milliliters)
        {
            Caffeine = caffeine;
        }

        public Coffee(string name, double caffeine) : this(name, caffeine, 0, 0)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
        public override double Milliliters => 50;
        public override decimal Price => 3.5M;
    }
}
