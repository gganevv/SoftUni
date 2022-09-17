using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletsPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int treasureValue = int.Parse(Console.ReadLine());
            Queue<int> locks = new Queue<int>(locksArr);
            Stack<int> bullets = new Stack<int>(bulletsArr);
            int bulletCounter = 0;

            while (locks.Any() && bullets.Any())
            {
                bulletCounter++;
                int currentLock = locks.Peek();
                int currentBullet = bullets.Pop();
                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if (bulletCounter % barrelSize == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int moneyEarned = treasureValue - (bulletCounter * bulletsPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }

        }
    }
}
