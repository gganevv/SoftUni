using System;
using System.Linq;

namespace _09.Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            char[,] matrix = new char[size, size];
            FillMatrix(matrix, size);

            int[] currentPosition = new int[2];
            int[] endPosition = new int[2];
            FindStartAndEndPosition(matrix, size, ref currentPosition, ref endPosition);
            int remainingCoal = FindRemainingCoal(matrix, size);
            int collectedCoal = 0;

            for (int i = 0; i < commands.Length; i++)
            {
                int[] currentCell = new int[2];
                switch (commands[i])
                {
                    case "down":
                        if (ValidCell(currentPosition[0] + 1, currentPosition[1], size))
                        {
                            currentCell[0] = currentPosition[0] + 1;
                            currentCell[1] = currentPosition[1];
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "up":
                        if (ValidCell(currentPosition[0] - 1, currentPosition[1], size))
                        {
                            currentCell[0] = currentPosition[0] - 1;
                            currentCell[1] = currentPosition[1];
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "left":
                        if (ValidCell(currentPosition[0], currentPosition[1] - 1, size))
                        {
                            currentCell[0] = currentPosition[0];
                            currentCell[1] = currentPosition[1] - 1;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    case "right":
                        if (ValidCell(currentPosition[0], currentPosition[1] + 1, size))
                        {
                            currentCell[0] = currentPosition[0];
                            currentCell[1] = currentPosition[1] + 1;
                        }
                        else
                        {
                            continue;
                        }
                        break;
                    default:
                        break;
                }

                if (matrix[currentCell[0], currentCell[1]] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentCell[0]}, {currentCell[1]})");
                    return;
                }
                else if (matrix[currentCell[0], currentCell[1]] == 'c')
                {
                    matrix[currentCell[0], currentCell[1]] = '*';
                    collectedCoal++;
                    currentPosition[0] = currentCell[0];
                    currentPosition[1] = currentCell[1];
                }
                else if (matrix[currentCell[0], currentCell[1]] == '*' || matrix[currentCell[0], currentCell[1]] == 's')
                {
                    currentPosition[0] = currentCell[0];
                    currentPosition[1] = currentCell[1];
                }

                if (collectedCoal == remainingCoal)
                {
                    Console.WriteLine($"You collected all coals! ({currentCell[0]}, {currentCell[1]})");
                    return;
                }
            }
            Console.WriteLine($"{remainingCoal - collectedCoal} coals left. ({currentPosition[0]}, {currentPosition[1]})");
        }

        private static bool ValidCell(int row, int col, int size)
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }

        private static int FindRemainingCoal(char[,] matrix, int size)
        {
            int coal = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coal++;
                    }
                }
            }

            return coal;
        }

        private static void FindStartAndEndPosition(char[,] matrix, int size, ref int[] startPosition, ref int[] endPosition)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        startPosition = new int[] { row, col };
                    }
                    if (matrix[row, col] == 'e')
                    {
                        endPosition = new int[] { row, col };
                    }
                }
            }
        }

        private static void FillMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                char[] colElements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => char.Parse(x)).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }
    }
}
