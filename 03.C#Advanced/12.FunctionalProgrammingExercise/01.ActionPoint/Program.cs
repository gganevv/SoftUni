using System;

namespace _01.ActionPoint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printNames = (names) =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine(name);
                }
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            printNames(names);
        }
    }
}
