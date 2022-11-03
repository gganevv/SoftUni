namespace _03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            List<Product> products = new List<Product>();
            List<Person> people = new List<Person>();
            string[] peopleList = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < peopleList.Length; i++)
            {
                
                try
                {
                    string[] personArgs = peopleList[i].Split("=");
                    string name = personArgs[0];
                    double money = double.Parse(personArgs[1]);
                    Person person = new Person(name, money);
                    people.Add(person);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
            }


            string[] productList = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < productList.Length; i++)
            {
                
                try
                {
                    string[] productArgs = productList[i].Split("=");
                    string name = productArgs[0];
                    double cost = double.Parse(productArgs[1]);
                    Product product = new Product(name, cost);
                    products.Add(product);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
                
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string personName = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).First();
                string productName = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Last();
                Person person = people.FirstOrDefault(x => x.Name == personName);
                Product product = products.FirstOrDefault(x => x.Name == productName);
                person.BuyProduct(product);

                input = Console.ReadLine();
            }

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
