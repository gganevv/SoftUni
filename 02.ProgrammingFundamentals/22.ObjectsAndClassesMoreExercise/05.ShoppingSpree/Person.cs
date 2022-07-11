using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ShoppingSpree
{
    public class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }
        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> Bag { get; set; }

        public void Buy(Product product)
        {
            if (Money - product.Price >= 0)
            {
                Money -= product.Price;
                Bag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name + " - ");
            if (Bag.Count > 0)
            {
                sb.Append(string.Join(", ", Bag.Select(x => x.Name)));
            }
            else
            {
                sb.Append($"Nothing bought");
            }

            return sb.ToString();
        }
    }
}
