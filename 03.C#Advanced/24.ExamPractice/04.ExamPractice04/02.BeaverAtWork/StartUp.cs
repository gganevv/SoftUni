using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    public class StartUp
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int wood = 0;
            int beaverX = 0;
            int beaverY = 0;
            List<char> fuckYou = new List<char>();
            char[,] matrix = FillMatrix(size, ref wood, ref beaverX, ref beaverY);
            string command = Console.ReadLine();
            while (command != "end" && wood > 0)
            {
                int currentX = beaverX;
                int currentY = beaverY;

                switch (command)
                {
                    case "up":
                        currentX--;
                        break;
                    case "down":
                        currentX++;
                        break;
                    case "left":
                        currentY--;
                        break;
                    case "right":
                        currentX++;
                        break;
                    default:
                        break;
                }

                bool validPosition = ValidatePosition(currentX, currentY, size);
                if (!validPosition)
                {
                    if (fuckYou.Count > 0)
                    {
                        fuckYou.RemoveAt(fuckYou.Count - 1);
                    }
                }
                else
                {
                    char currentPosition = matrix[currentX, currentY];
                    if (currentPosition >= 97 && currentPosition <= 122)
                    {
                        wood--;
                        fuckYou.Add(currentPosition);
                        matrix[beaverX, beaverY] = '-';
                        beaverX = currentX;
                        beaverY = currentY;
                        matrix[beaverX, beaverY] = 'B';
                    }
                    else
                    {
                        if (currentX != 0 && currentY != 0 && currentX < size && currentY < size)
                        {
                            switch (command)
                            {
                                case "up":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = 0;
                                    beaverY = currentY;
                                    if (matrix[0, beaverY] >= 97 && matrix[0, beaverY] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "down":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = size - 1;
                                    beaverY = currentY;
                                    if (matrix[size - 1, beaverY] >= 97 && matrix[size - 1, beaverY] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "left":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = currentX;
                                    beaverY = 0;
                                    if (matrix[beaverX, 0] >= 97 && matrix[beaverX, 0] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "right":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = currentX;
                                    beaverY = size - 1;
                                    if (matrix[beaverX, size - 1] >= 97 && matrix[beaverX, size - 1] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                        {
                            switch (command)
                            {
                                case "down":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = 0;
                                    beaverY = currentY;
                                    if (matrix[0, beaverY] >= 97 && matrix[0, beaverY] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "up":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = size - 1;
                                    beaverY = currentY;
                                    if (matrix[size - 1, beaverY] >= 97 && matrix[size - 1, beaverY] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "right":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = currentX;
                                    beaverY = 0;
                                    if (matrix[beaverX, 0] >= 97 && matrix[beaverX, 0] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                case "left":
                                    matrix[beaverX, beaverY] = '-';
                                    beaverX = currentX;
                                    beaverY = size - 1;
                                    if (matrix[beaverX, size - 1] >= 97 && matrix[beaverX, size - 1] <= 122)
                                    {
                                        fuckYou.Add(currentPosition);
                                        wood--;
                                    }
                                    matrix[beaverX, beaverY] = 'B';
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }

            if (wood > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {wood} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {fuckYou.Count} wood branches: {string.Join(", ", fuckYou)}.");
            }

            PrintMatrix(matrix, size);

        }

        private static void PrintMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool ValidatePosition(int currentX, int currentY, int size) => currentX >= 0 && currentY >= 0 && currentX < size && currentY < size;

        private static char[,] FillMatrix(int size, ref int wood, ref int beaverX, ref int beaverY)
        {
            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                char[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    char currentElement = colElements[col];
                    matrix[row, col] = currentElement;

                    if (currentElement == 'B')
                    {
                        beaverX = row;
                        beaverY = col;
                    }

                    if (currentElement >= 97 && currentElement <= 122)
                    {
                        wood++;
                    }
                }
            }

            return matrix;
        }
    }
}
