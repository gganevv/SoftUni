using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                int index = int.Parse(commandArgs[1]);
                int value = int.Parse(commandArgs[2]);

                switch (command)
                {
                    case "Shoot":
                        Shoot(index, value, targets);
                        break;
                    case "Add":
                        Add(index, value, targets);
                        break;
                    case "Strike":
                        Strike(index, value, targets);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join("|", targets));
        }

        private static void Shoot(int index, int value, List<int> targets)
        {
            if (ValidIndex(index, targets))
            {
                targets[index] -= value;
                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }
            
        }

        private static void Add(int index, int value, List<int> targets)
        {
            if (ValidIndex(index, targets))
            {
                targets.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }

        private static void Strike(int index, int value, List<int> targets)
        {
            int start = index - value;
            int end = index + value;
            if (ValidIndex(start, end, targets))
            {
                targets.RemoveRange(start, value * 2 + 1);
            }
            else
            {
                Console.WriteLine("Strike missed!");
            }
        }

        private static bool ValidIndex(int index, List<int> targets)
        {
            return index >= 0 && index < targets.Count;
        }

        private static bool ValidIndex(int start, int end, List<int> targets)
        {
            return start >= 0 && end < targets.Count;
        }
    }
}
