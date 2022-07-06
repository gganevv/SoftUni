using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine().Split("!").ToList();

            string input = Console.ReadLine();

            while (input != "Go Shopping!")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                string item = commandArgs[1];

                switch (command)
                {
                    case "Urgent":
                        Urgent(item, shoppingList);
                        break;
                    case "Unnecessary":
                        Unnecessary(item, shoppingList);
                        break;
                    case "Correct":
                        string secondItem = commandArgs[2];
                        Correct(item, secondItem, shoppingList);
                        break;
                    case "Rearrange":
                        Rearrange(item, shoppingList);
                        break;
                    default:
                        break;
                }


                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }

        private static void Urgent(string item, List<string> shoppingList)
        {
            if (!shoppingList.Contains(item))
            {
                shoppingList.Insert(0, item);
            }
        }

        private static void Unnecessary(string item, List<string> shoppingList)
        {
            if (shoppingList.Contains(item))
            {
                shoppingList.Remove(item);
            }
        }

        private static void Correct(string item, string secondItem, List<string> shoppingList)
        {
            if (shoppingList.Contains(item))
            {
                shoppingList[shoppingList.IndexOf(item)] = secondItem;
            }
        }

        private static void Rearrange(string item, List<string> shoppingList)
        {
            if (shoppingList.Contains(item))
            {
                shoppingList.Remove(item);
                shoppingList.Add(item);
            }
        }
    }
}
