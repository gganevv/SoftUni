using System;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int mostAtackingRow = 0;
                int mostAtackingCol = 0;
                int mostAtackingCount = FindMostAtackingCount(matrix, ref mostAtackingRow, ref mostAtackingCol);

                if (mostAtackingCount == 0)
                {
                    break;
                }
                else
                {
                    matrix[mostAtackingRow, mostAtackingCol] = '0';
                    knightsRemoved++;
                }
            }


            Console.WriteLine(knightsRemoved);
        }

        private static int FindMostAtackingCount(char[,] matrix, ref int mostAtackingRow, ref int mostAtackingCol)
        {
            int mostAtackingCount = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'K')
                    {
                        int atackedKnights = CheckAtackedKnights(row, col, matrix);
                        if (atackedKnights > mostAtackingCount)
                        {
                            mostAtackingCount = atackedKnights;
                            mostAtackingRow = row;
                            mostAtackingCol = col;
                        }
                    }
                }
            }

            return mostAtackingCount;
        }

        private static int CheckAtackedKnights(int row, int col, char[,] matrix)
        {
            int atackedKnights = 0;

            if (ValidIndex(row - 2, col - 1, matrix))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row - 2, col + 1, matrix))
            {
                if (matrix[row - 2, col + 1] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row - 1, col - 2, matrix))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row - 1, col + 2, matrix))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row + 1, col - 2, matrix))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row + 1, col + 2, matrix))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row + 2, col - 1, matrix))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    atackedKnights++;
                }
            }
            if (ValidIndex(row + 2, col + 1, matrix))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    atackedKnights++;
                }
            }

            return atackedKnights;
        }

        private static bool ValidIndex(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}