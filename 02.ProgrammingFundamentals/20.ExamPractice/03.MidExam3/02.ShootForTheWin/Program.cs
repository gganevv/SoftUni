using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command = Console.ReadLine();
            int count = 0;
            int targetValue = 0;

            while (command != "End")
            {
                int index = int.Parse(command);
                if (index < targets.Count && index >= 0)
                {
                    targetValue = targets[index];
                    targets[index] = -1;
                    count++;

                    for (int i = 0; i < targets.Count; i++)
                    {
                        if (targets[i] != -1 && targets[i] > targetValue)
                        {
                            targets[i] -= targetValue;
                        }
                        else if(targets[i] != -1 && targets[i] <= targetValue)
                        {
                            targets[i] += targetValue;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.Write($"Shot targets: {count} -> ");
            Console.WriteLine(string.Join(" ", targets));
        }
    }
}
