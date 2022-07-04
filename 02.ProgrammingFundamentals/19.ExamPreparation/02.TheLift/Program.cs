using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            List<int> lift = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool morePeople = true;
            bool enoughSpace = true;

            for (int i = 0; i < lift.Count; i++)
            {
                while (lift[i] != 4 && people != 0)
                {

                    lift[i]++;
                    people--;
                }
                if (people == 0)
                {
                    morePeople = false;
                }
                if (i == lift.Count - 1 && lift[i] == 4)
                {
                    enoughSpace = false;
                }
            }
            if (!morePeople && enoughSpace)
            {
                Console.WriteLine("The lift has empty spots!");
            }
            else if (morePeople && !enoughSpace)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
            }
            Console.WriteLine(string.Join(" ", lift));
        }
    }
}
