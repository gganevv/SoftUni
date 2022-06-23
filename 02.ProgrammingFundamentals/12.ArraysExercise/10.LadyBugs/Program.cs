using System;
using System.Linq;

namespace _10.LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] initialPositions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];

            foreach (int bug in initialPositions)
            {
                if (bug < fieldSize && bug >= 0)
                {
                    field[bug] = 1;
                }
            }

            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandArgs = command.Split();
                int bugIndex = int.Parse(commandArgs[0]);
                string bugDirection = commandArgs[1];
                int bugFlyLength = int.Parse(commandArgs[2]);

                if (bugIndex < field.Length && bugIndex >= 0 && field[bugIndex] == 1 && bugFlyLength != 0)
                {
                    int desiredSpot = bugDirection == "right" ? bugIndex + bugFlyLength : bugIndex - bugFlyLength;
                    Fly(fieldSize, field, bugIndex, bugFlyLength, desiredSpot, bugDirection);
                }
                command = Console.ReadLine();
            }

            foreach (int bug in field)
            {
                Console.Write($"{bug} ");
            }
        }

        private static void Fly(int fieldSize, int[] field, int bugIndex, int bugFlyLength, int desiredSpot, string bugDirection)
        {
            if (desiredSpot >= fieldSize || desiredSpot < 0)
            {
                field[bugIndex] = 0;
            }
            else if (field[desiredSpot] == 1)
            {
                ContinueFlying(field, bugIndex, bugFlyLength, desiredSpot, bugDirection);
            }
            else
            {
                field[bugIndex] = 0;
                field[desiredSpot] = 1;
            }
        }

        private static void ContinueFlying(int[] field, int bugIndex, int bugFlyLength, int desiredSpot, string bugDirection)
        {
            while (field[desiredSpot] == 1)
            {
                desiredSpot = CalculateNewSpot(bugFlyLength, desiredSpot, bugDirection);
                if (desiredSpot > field.Length - 1)
                {
                    break;
                }
            }
            if (desiredSpot < field.Length)
            {
                field[bugIndex] = 0;
                field[desiredSpot] = 1;
            }
            else
            {
                field[bugIndex] = 0;
            }
        }

        private static int CalculateNewSpot(int bugFlyLength, int desiredSpot, string bugDirection)
        {
            if (bugDirection == "left")
            {
                desiredSpot -= bugFlyLength;
            }
            else
            {
                desiredSpot += bugFlyLength;
            }

            return desiredSpot;
        }
    }
}
