namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFEE_PRICE = 3.5M;
        public Coffee(string name, double caffeine) : base(name, COFEE_PRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
