using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        private const int MAX_SPACE = 4;
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] elevators = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool noMorePeople = false;
            bool fullLift = false;

            for (int i = 0; i < elevators.Length && people > 0; i++)
            {
                while (elevators[i] < MAX_SPACE)
                {
                    elevators[i]++;
                    people--;
                    if (people == 0)
                    {
                        noMorePeople = true;
                        break;
                    }
                }

                if (i == elevators.Length - 1 && elevators[i] == 4)
                {
                    fullLift = true;
                }
            }

            if (noMorePeople && !fullLift)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", elevators));
            }
            else if (!noMorePeople && fullLift)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", elevators));
            }
            else
            {
                Console.WriteLine(string.Join(" ", elevators));
            }
        }
    }
}
