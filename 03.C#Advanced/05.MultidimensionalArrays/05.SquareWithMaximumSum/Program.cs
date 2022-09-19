using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];
            int[] bestMatrix = new int[4];
            int maxSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        bestMatrix[0] = matrix[row, col];
                        bestMatrix[1] = matrix[row, col + 1];
                        bestMatrix[2] = matrix[row + 1, col];
                        bestMatrix[3] = matrix[row + 1, col + 1];
                    }
                }
            }
            Console.WriteLine($"{bestMatrix[0]} {bestMatrix[1]}");
            Console.WriteLine($"{bestMatrix[2]} {bestMatrix[3]}");

            Console.WriteLine(maxSum);
        }
    }
}
