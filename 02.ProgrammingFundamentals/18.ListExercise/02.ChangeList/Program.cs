using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] commandArgs = command.Split();
                if (commandArgs[0] == "Delete")
                {
                    int numberToDelete = int.Parse(commandArgs[1]);
                    numbers.RemoveAll(x => x == numberToDelete);
                }
                else if (commandArgs[0] == "Insert")
                {
                    int element = int.Parse(commandArgs[1]);
                    int position = int.Parse(commandArgs[2]);
                    numbers.Insert(position, element);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
