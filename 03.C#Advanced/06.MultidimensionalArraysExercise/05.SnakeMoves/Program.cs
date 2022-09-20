using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            char[,] matrix = new char[rows, cols];

            string input = Console.ReadLine();
            int splitTimes = rows * cols / input.Length;
            Queue<char> inputQueue = new Queue<char>(string.Concat(Enumerable.Repeat(input, rows * 5)).ToArray());

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = inputQueue.Dequeue();
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = inputQueue.Dequeue();
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
