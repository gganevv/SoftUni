using System;

namespace _04.Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsNeeded = 10000;
            int steps = 0;
            while (steps < stepsNeeded)
            {
                string command = Console.ReadLine();
                if (command != "Going home")
                {
                    steps += int.Parse(command);
                }
                else
                {
                    steps += int.Parse(Console.ReadLine());
                    break;
                }
            }

            if (steps >= stepsNeeded)
            {
            Console.WriteLine("Goal reached! Good job!");
            Console.WriteLine($"{steps - stepsNeeded} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{stepsNeeded - steps} more steps to reach goal.");
            }
        }
    }
}
