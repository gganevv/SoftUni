using System;
using System.Collections.Generic;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            string[] peopleInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            string[] productInput = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < peopleInput.Length; i++)
            {
                string[] peopleArgs = peopleInput[i].Split("=");
                string personName = peopleArgs[0];
                int personMoney = int.Parse(peopleArgs[1]);

                people.Add(new Person(personName, personMoney));
            }

            for (int i = 0; i < productInput.Length; i++)
            {
                string[] productArgs = productInput[i].Split("=");
                string productName = productArgs[0];
                int productPrice = int.Parse(productArgs[1]);

                products.Add(new Product(productName, productPrice));
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] buyArgs = command.Split();
                string personName = buyArgs[0];
                string productName = buyArgs[1];
                Person person = people.Find(x => x.Name == personName);
                Product product = products.Find(x => x.Name == productName);
                person.Buy(product);

                command = Console.ReadLine();
            }

            people.ForEach(x => Console.WriteLine(x));
        }
    }
}
