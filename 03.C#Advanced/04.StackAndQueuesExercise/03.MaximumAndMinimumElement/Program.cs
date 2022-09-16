using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>();
            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                int command = int.Parse(inputArgs[0]);
                if (command == 1)
                {
                    nums.Push(int.Parse(inputArgs[1]));
                }
                else if (nums.Count > 0)
                {
                    switch (command)
                    {
                        case 2:
                            nums.Pop();
                            break;
                        case 3:
                            Console.WriteLine(nums.Max());
                            break;
                        case 4:
                            Console.WriteLine(nums.Min());
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine(String.Join(", ", nums));
        }
    }
}