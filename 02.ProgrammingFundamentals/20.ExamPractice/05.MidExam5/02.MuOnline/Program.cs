using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 100;
            int bitcoins = 0;
            bool dead = false;

            List<string> rooms = Console.ReadLine().Split("|").ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                string[] roomTokens = rooms[i].Split();
                string roomType = roomTokens[0];
                int roomValue = int.Parse(roomTokens[1]);

                if (roomType == "potion")
                {
                    if (health + roomValue <= 100)
                    {
                        health += roomValue;
                        Console.WriteLine($"You healed for {roomValue} hp.");
                    }
                    else
                    {
                        Console.WriteLine($"You healed for {100 - health} hp.");
                        health = 100;
                    }
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (roomType == "chest")
                {
                    bitcoins += roomValue;
                    Console.WriteLine($"You found {roomValue} bitcoins.");
                }
                else
                {
                    health -= roomValue;
                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {roomType}.");
                    }
                    else
                    {
                        Console.WriteLine($"You died! Killed by {roomType}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        dead = true;
                        break;
                    }
                }
            }

            if (!dead)
            {
                Console.WriteLine("You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}
