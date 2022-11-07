namespace FoodShortage.Models.Interfaces
{
    public interface IBuyer
    {
        public string Name { get; }
        public int Age { get; }
        public int Food { get; }
        public void BuyFood();
    }
}
