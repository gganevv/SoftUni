using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(nums);

            string input = Console.ReadLine().ToLower();
            while (input != "end")
            {
                string[] inputArgs = input.Split();
                if (inputArgs[0] == "add")
                {
                    stack.Push(int.Parse(inputArgs[1]));
                    stack.Push(int.Parse(inputArgs[2]));
                }
                else if (inputArgs[0] == "remove")
                {
                    int count = int.Parse(inputArgs[1]);
                    if (stack.Count > count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }

                input = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
