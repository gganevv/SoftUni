using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.TruffleHunter
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            FillMatrix(size, matrix);
            int trufflesEaten = 0;

            Dictionary<char, int> truffles = new Dictionary<char, int>()
            {
                { 'B', 0 },
                { 'S', 0 },
                { 'W', 0 }
            };

            string input = Console.ReadLine();

            while (input != "Stop the hunt")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);

                if (command == "Collect")
                {
                    if (matrix[row, col] != '-')
                    {
                        truffles[matrix[row, col]]++;
                        matrix[row, col] = '-';
                    }
                }
                else if (command == "Wild_Boar")
                {
                    string direction = inputArgs[3];
                    trufflesEaten += MoveBear(row, col, direction, matrix);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Peter manages to harvest {truffles['B']} black, {truffles['S']} summer, and {truffles['W']} white truffles.");
            Console.WriteLine($"The wild boar has eaten {trufflesEaten} truffles.");
            PrintMatrix(matrix, size);
        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static int MoveBear(int row, int col, string direction, char[,] matrix)
        {
            int eatenTruffles = 0;
            switch (direction)
            {
                case "up":
                    for (int currentRow = row; currentRow >= 0; currentRow -= 2)
                    {
                        if (matrix[currentRow, col] == 'B' || matrix[currentRow, col] == 'S' || matrix[currentRow, col] == 'W')
                        {
                            eatenTruffles++;
                        }
                        matrix[currentRow, col] = '-';
                    }
                    break;
                case "down":
                    for (int currentRow = row; currentRow < matrix.GetLength(0); currentRow += 2)
                    {
                        if (matrix[currentRow, col] == 'B' || matrix[currentRow, col] == 'S' || matrix[currentRow, col] == 'W')
                        {
                            eatenTruffles++;
                        }
                        matrix[currentRow, col] = '-';
                    }
                    break;
                case "left":
                    for (int currentCol = col; currentCol >= 0; currentCol -= 2)
                    {
                        if (matrix[row, currentCol] == 'B' || matrix[row, currentCol] == 'S' || matrix[row, currentCol] == 'W')
                        {
                            eatenTruffles++;
                        }
                        matrix[row, currentCol] = '-';
                    }
                    break;
                case "right":
                    for (int currentCol = col; currentCol < matrix.GetLength(0); currentCol += 2)
                    {
                        if (matrix[row, currentCol] == 'B' || matrix[row, currentCol] == 'S' || matrix[row, currentCol] == 'W')
                        {
                            eatenTruffles++;
                        }
                        matrix[row, currentCol] = '-';
                    }
                    break;
                default:
                    break;
            }

            return eatenTruffles;
        }

        private static void FillMatrix(int size, char[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                char[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }
        }
    }
}