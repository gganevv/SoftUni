using System;
using System.Linq;

namespace _03.PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];
            int sum = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                int[] colElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrixSize; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    if (col == row)
                    {
                        sum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
