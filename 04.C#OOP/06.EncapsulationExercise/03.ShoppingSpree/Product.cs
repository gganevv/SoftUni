using System;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private double price;

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME_EXCEPTION);
                }
                name = value;
            }
        }

        public double Price
        {
            get => price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_MONEY_EXCEPTION);
                }
                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}