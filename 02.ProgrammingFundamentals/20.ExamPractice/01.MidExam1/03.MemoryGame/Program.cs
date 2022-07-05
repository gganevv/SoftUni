using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int counter = 0;
            string command = Console.ReadLine();

            while (command != "end")
            {
                counter++;
                string[] commandArgs = command.Split();
                int firstIndex = int.Parse(commandArgs[0]);
                int secondIndex = int.Parse(commandArgs[1]);

                bool cheating = firstIndex == secondIndex || firstIndex < 0 || firstIndex > elements.Count - 1 || secondIndex < 0 || secondIndex > elements.Count - 1;
                if (cheating)
                {
                    elements.Insert(elements.Count / 2, $"-{counter}a");
                    elements.Insert(elements.Count / 2, $"-{counter}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                    elements.RemoveAt(firstIndex);
                    if (firstIndex < secondIndex)
                    {
                        elements.RemoveAt(secondIndex - 1);
                    }
                    else
                    {
                        elements.RemoveAt(secondIndex);
                    }
                }
                else
                {
                    Console.WriteLine("Try again!");
                }


                if (elements.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    return;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine("Sorry you lose :(");
            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
