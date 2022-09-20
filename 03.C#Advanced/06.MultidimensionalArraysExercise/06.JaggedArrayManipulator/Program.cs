using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            PopulateMatrix(rows, jaggedArray);
            AnalizeMatrix(rows, jaggedArray);

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputArgs = input.Split(' ');
                string command = inputArgs[0];
                int row = int.Parse(inputArgs[1]);
                int col = int.Parse(inputArgs[2]);
                int value = int.Parse(inputArgs[3]);
                bool validIndex = CheckValidIndex(row, col, jaggedArray);

                if (validIndex) {
                    if (command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if (command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
                

                input = Console.ReadLine();
            }

            PrintMatrix(jaggedArray);
        }

        private static bool CheckValidIndex(int row, int col, int[][] jaggedArray)
        {
            if (row >= 0 && jaggedArray.Length - 1 >= row)
            {
                if (col >= 0 && jaggedArray[row].Length -1 >= col)
                {
                    return true;
                }
            }
            return false;
        }

        private static void PopulateMatrix(int rows, int[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                jaggedArray[row] = colElements;
            }
        }

        private static void AnalizeMatrix(int rows, int[][] jaggedArray)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {
                        jaggedArray[row + 1][col] /= 2;
                    }
                }
            }
        }
        private static void PrintMatrix(int[][] jaggedArray)
        {
            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", row));
            }
        }
    }
}
