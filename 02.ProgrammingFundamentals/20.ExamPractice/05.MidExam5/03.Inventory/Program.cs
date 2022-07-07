using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "Craft!")
            {
                string[] commandTokens = input.Split(" - ");
                string command = commandTokens[0];
                string item = commandTokens[1];

                switch (command)
                {
                    case "Collect":
                        Collect(item, inventory);
                        break;
                    case "Drop":
                        Drop(item, inventory);
                        break;
                    case "Combine Items":
                        CombineItems(item, inventory);
                        break;
                    case "Renew":
                        Renew(item, inventory);
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }

        private static void Collect(string item, List<string> inventory)
        {
            if (!inventory.Contains(item))
            {
                inventory.Add(item);
            }
        }

        private static void Drop(string item, List<string> inventory)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
            }
        }

        private static void CombineItems(string item, List<string> inventory)
        {
            string[] items = item.Split(":");
            string firstElement = items[0];
            string secondElement = items[1];

            if (inventory.Contains(firstElement))
            {
                if (inventory.IndexOf(firstElement) < inventory.Count - 1)
                {
                    inventory.Insert(inventory.IndexOf(firstElement) + 1, secondElement);
                }
                else
                {
                    inventory.Add(secondElement);
                }
            }
        }

        private static void Renew(string item, List<string> inventory)
        {
            if (inventory.Contains(item))
            {
                inventory.Remove(item);
                inventory.Add(item);
            }
        }
    }
}
