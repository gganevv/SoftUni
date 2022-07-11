namespace _05.ShoppingSpree
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
