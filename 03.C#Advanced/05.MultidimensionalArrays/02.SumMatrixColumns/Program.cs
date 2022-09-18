using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] colElements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row,col] = colElements[col];
                }
            }

            int colSum = 0;

            for (int col = 0; col < cols; col++)
            {
                colSum = 0;
                for (int row = 0; row < rows; row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }
        }
    }
}
