using System;

namespace _07.PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            long[][] triangle = new long[rows][];
            triangle[0] = new long[] { 1 };

            for (int row = 1; row < rows; row++)
            {
                triangle[row] = new long[row + 1];
                triangle[row][0] = 1;
                for (int col = 1; col < row; col++)
                {
                    triangle[row][col] = triangle[row - 1][col - 1] + triangle[row - 1][col];
                }
                triangle[row][row] = 1;
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(String.Join(" ", triangle[row]));
            }
        }
    }
}
