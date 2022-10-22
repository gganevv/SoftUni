using System;
using System.Linq;

namespace _02.RallyRacing
{
    public class StartUp
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            char[,] matrix = FillMatrix(size);
            int carX = 0;
            int carY = 0;
            int distance = 0;
            bool won = false;

            string command = Console.ReadLine();
            while (command != "End")
            {
                int newX = carX;
                int newY = carY;
                switch (command)
                {
                    case "up":
                        newX--;
                        break;
                    case "down":
                        newX++;
                        break;
                    case "left":
                        newY--;
                        break;
                    case "right":
                        newY++;
                        break;
                    default:
                        break;
                }

                if (matrix[newX, newY] == '.')
                {
                    distance += 10;
                    carX = newX;
                    carY = newY;
                }
                else if (matrix[newX, newY] == 'F')
                {
                    carX = newX;
                    carY = newY;
                    distance += 10;
                    won = true;
                    break;
                }
                else if (matrix[newX, newY] == 'T')
                {
                    distance += 30;
                    matrix[newX, newY] = '.';
                    int[] nextTunel = FindNexTunel(matrix, size);
                    matrix[nextTunel[0], nextTunel[1]] = '.';
                    carX = nextTunel[0];
                    carY = nextTunel[1];

                }

                command = Console.ReadLine();
            }
            matrix[carX, carY] = 'C';

            if (won)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {distance} km.");
            PrintMatrix(matrix, size);
        }

        private static int[] FindNexTunel(char[,] matrix, int size)
        {
            int[] result = new int[2];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'T')
                    {
                        result[0] = row;
                        result[1] = col;
                    }
                }
            }

            return result;
        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] FillMatrix(int size)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            return matrix;
        }
    }
}
