using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                switch (command)
                {
                    case "Add":
                        Add(numbers, commandArgs);
                        break;
                    case "Insert":
                        Insert(numbers, commandArgs);
                        break;
                    case "Remove":
                        Remove(numbers, commandArgs);
                        break;
                    case "Shift":
                        Shift(commandArgs, numbers);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static void Add(List<int> numbers, string[] commandArgs)
        {
            int numberToAdd = int.Parse(commandArgs[1]);
            numbers.Add(numberToAdd);
        }

        private static void Insert(List<int> numbers, string[] commandArgs)
        {
            int numberToInsert = int.Parse(commandArgs[1]);
            int indexToInsert = int.Parse(commandArgs[2]);
            if (IndexIsValid(indexToInsert, numbers))
            {
                numbers.Insert(indexToInsert, numberToInsert);
            }
        }

        private static void Remove(List<int> numbers, string[] commandArgs)
        {
            int indexToRemove = int.Parse(commandArgs[1]);
            if (IndexIsValid(indexToRemove, numbers))
            {
                numbers.RemoveAt(indexToRemove);
            }
        }

        private static void Shift(string[] commandArgs, List<int> numbers)
        {
            string direction = commandArgs[1];
            int count = int.Parse(commandArgs[2]);
            if (direction == "left")
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(numbers[0]);
                    numbers.RemoveAt(0);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Insert(0, numbers[numbers.Count - 1]);
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
        }

        private static bool IndexIsValid(int index, List<int> numbers)
        {
            if (index >= 0 && index < numbers.Count)
            {
                return true;
            }
            Console.WriteLine("Invalid index");
            return false;
        }
    }
}
