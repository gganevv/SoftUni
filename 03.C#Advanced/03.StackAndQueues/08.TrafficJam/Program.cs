using System;
using System.Collections.Generic;

namespace _08.TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int carsToPass = int.Parse(Console.ReadLine());
            int carsCounter = 0;
            Queue<string> carsQueue = new Queue<string>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < carsToPass; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            carsCounter++;
                        }
                    }
                }
                else
                {
                    carsQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{carsCounter} cars passed the crossroads.");
        }
    }
}
