using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            FillMatrix(size, matrix);

            string[] bombs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] currentBomb = bombs[i].Split(",").Select(x => int.Parse(x)).ToArray();
                int bombRow = currentBomb[0];
                int bombCol = currentBomb[1];
                int bombValue = 0;

                if (!ValidCell(bombRow, bombCol, size) || !CheckCellAlive(bombRow, bombCol, matrix))
                {
                    continue;
                }
                bombValue = matrix[bombRow, bombCol];

                DetonateBomb(size, matrix, bombRow, bombCol, bombValue);
            }

            List<int> aliveCells = CheckAllAliveCells(matrix);
            Console.WriteLine($"Alive cells: {aliveCells.Count}");
            Console.WriteLine($"Sum: {aliveCells.Sum()}");
            PrintMatrix(matrix, size);
        }

        private static List<int> CheckAllAliveCells(int[,] matrix)
        {
            List<int> aliveCells = new List<int>();
            foreach (int cell in matrix)
            {
                if (cell > 0)
                {
                    aliveCells.Add(cell);
                }
            }

            return aliveCells;
        }

        private static void PrintMatrix(int[,] matrix, int size)
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

        private static void DetonateBomb(int size, int[,] matrix, int bombRow, int bombCol, int bombValue)
        {
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (ValidCell(bombRow + i, bombCol + j, size))
                    {
                        if (CheckCellAlive(bombRow + i, bombCol + j, matrix))
                        {
                            matrix[bombRow + i, bombCol + j] -= bombValue;
                        }
                    }
                }
            }
        }

        private static bool CheckCellAlive(int row, int col, int[,] matrix)
        {
            return matrix[row, col] > 0;
        }

        private static bool ValidCell(int bombRow, int bombCol, int size)
        {
            return bombRow >= 0 && bombRow < size && bombCol >= 0 && bombCol < size;
        }

        private static void FillMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                int[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
    }
}
