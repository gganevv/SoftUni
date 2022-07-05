using System;
using System.Linq;

namespace _02.ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                switch (commandArgs[0])
                {
                    case "swap":
                        Swap(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]), numbers);
                        break;
                    case "multiply":
                        Multiply(int.Parse(commandArgs[1]), int.Parse(commandArgs[2]), numbers);
                        break;
                    case "decrease":
                        Decrease(numbers);
                        break;
                    default:
                        break;
                }


                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static void Swap(int firstIndex, int secondIndex, int[] numbers)
        {
            int temp = numbers[firstIndex];
            numbers[firstIndex] = numbers[secondIndex];
            numbers[secondIndex] = temp;
        }

        private static void Multiply(int firstIndex, int secondIndex, int[] numbers)
        {
            numbers[firstIndex] *= numbers[secondIndex];
        }

        private static void Decrease(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]--;
            }
        }
    }
}
