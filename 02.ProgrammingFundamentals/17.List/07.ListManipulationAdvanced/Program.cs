using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            bool changed = false;

            while (input != "end")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                switch (command)
                {
                    case "Add":
                        int numberToAdd = int.Parse(commandArgs[1]);
                        numbers.Add(numberToAdd);
                        changed = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(commandArgs[1]);
                        numbers.Remove(numberToRemove);
                        changed = true;
                        break;
                    case "RemoveAt":
                        int indexToRemove = int.Parse(commandArgs[1]);
                        numbers.RemoveAt(indexToRemove);
                        changed = true;
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(commandArgs[1]);
                        int indexToInsert = int.Parse(commandArgs[2]);
                        numbers.Insert(indexToInsert, numberToInsert);
                        changed = true;
                        break;
                    case "Contains":
                        int checkNumber = int.Parse(commandArgs[1]);
                        CheckContains(checkNumber, numbers);
                        break;
                    case "PrintEven":
                        PrintEven(numbers);
                        break;
                    case "PrintOdd":
                        PrintOdd(numbers);
                        break;
                    case "GetSum":
                        GetSum(numbers);
                        break;
                    case "Filter":
                        string condition = commandArgs[1];
                        int numberToCheck = int.Parse(commandArgs[2]);
                        Filter(condition, numberToCheck, numbers);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            if (changed)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            
        }

        private static void Filter(string condition, int numberToCheck, List<int> numbers)
        {
            List<int> filteredList = new List<int>();
            
            switch (condition)
            {
                case "<":
                    filteredList = numbers.Where(x => x < numberToCheck).ToList();
                    break;
                case ">":
                    filteredList = numbers.Where(x => x > numberToCheck).ToList();
                    break;
                case ">=":
                    filteredList = numbers.Where(x => x >= numberToCheck).ToList();
                    break;
                case "<=":
                    filteredList = numbers.Where(x => x <= numberToCheck).ToList();
                    break;
                default:
                    break;
            }

            Console.WriteLine(string.Join(" ", filteredList));
        }

        private static void GetSum(List<int> numbers)
        {
            Console.WriteLine(numbers.Sum());
        }

        private static void PrintOdd(List<int> numbers)
        {
            List<int> evenNums = new List<int>();
            foreach (int n in numbers)
            {
                if (n % 2 != 0)
                {
                    evenNums.Add(n);
                }
            }

            Console.WriteLine(string.Join(" ", evenNums));
        }

        private static void PrintEven(List<int> numbers)
        {
            List<int> evenNums = new List<int>();
            foreach (int n in numbers)
            {
                if (n % 2 == 0)
                {
                    evenNums.Add(n);
                }
            }

            Console.WriteLine(string.Join(" ", evenNums));
        }

        private static void CheckContains(int checkNumber, List<int> numbers)
        {
            if (numbers.Contains(checkNumber))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }
        }
    }
}
