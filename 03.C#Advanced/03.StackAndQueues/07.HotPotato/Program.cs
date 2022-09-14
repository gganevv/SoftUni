using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            Queue<string> queue = new Queue<string>(kids);
            int count = int.Parse(Console.ReadLine());
            while (queue.Count > 1)
            {
                for (int i = 0; i < count - 1; i++)
                {
                    string currentKid = queue.Dequeue();
                    queue.Enqueue(currentKid);
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
