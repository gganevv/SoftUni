using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                bool validInput = inputArgs.Length == 5;
                if (validInput)
                {
                    int row1 = int.Parse(inputArgs[1]);
                    int col1 = int.Parse(inputArgs[2]);
                    int row2 = int.Parse(inputArgs[3]);
                    int col2 = int.Parse(inputArgs[4]);

                    bool validIndexes = CheckIndexes(row1, col1, row2, col2, matrix);
                    if (validIndexes)
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;
                    }
                    else
                    {
                        validInput = false;
                    }
                }

                if (validInput)
                {
                    PrintMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool CheckIndexes(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            return row1 >= 0 && row1 < matrix.GetLength(0)
            && col1 >= 0 && col1 < matrix.GetLength(1)
            && row2 >= 0 && row2 < matrix.GetLength(0)
            && col2 >= 0 && col2 < matrix.GetLength(1);
        }
    }
}
