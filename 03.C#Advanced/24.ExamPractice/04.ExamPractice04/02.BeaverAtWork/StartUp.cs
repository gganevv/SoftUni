using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BeaverAtWork
{
    public class StartUp
    {
        static void Main()
        {
            Beaver beaver = new Beaver();
            int totalWood = 0;

            int size = int.Parse(Console.ReadLine());
            char[,] matrix = FillMatrix(size, ref totalWood, beaver);

            string command = Console.ReadLine();
            while (command != "end" && totalWood > 0)
            {
                int currentX = beaver.X;
                int currentY = beaver.Y;

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
                        currentY++;
                        break;
                    default:
                        break;
                }

                bool validPosition = ValidatePosition(currentX, currentY, size);
                if (!validPosition)
                {
                    if (beaver.Branches.Count > 0)
                    {
                        beaver.Branches.RemoveAt(beaver.Branches.Count - 1);
                    }
                    command = Console.ReadLine();
                    continue;
                }


                char currentPosition = matrix[currentX, currentY];
                if (IsWood(currentPosition))
                {
                    totalWood--;
                    beaver.Branches.Add(currentPosition);
                }
                else if (currentPosition == 'F')
                {
                    matrix[currentX, currentY] = '-';
                    switch (command)
                    {
                        case "up":
                            if (currentX > 0)
                            {
                                currentX = 0;
                            }
                            else
                            {
                                currentX = size - 1;
                            }

                            break;
                        case "down":
                            if (currentX < size - 1)
                            {
                                currentX = size - 1;
                            }
                            else
                            {
                                currentX = 0;
                            }

                            break;
                        case "left":
                            if (currentY > 0)
                            {
                                currentY = 0;
                            }
                            else
                            {
                                currentY = size - 1;
                            }

                            break;
                        case "right":
                            if (currentY < size - 1)
                            {
                                currentY = size - 1;
                            }
                            else
                            {
                                currentY = 0;
                            }

                            break;
                    }

                    if (IsWood(matrix[currentX, currentY]))
                    {
                        beaver.Branches.Add(matrix[currentX, currentY]);
                        totalWood--;
                    }
                    matrix[currentX, currentY] = '-';

                }

                matrix[currentX, currentY] = '-';
                beaver.X = currentX;
                beaver.Y = currentY;

                command = Console.ReadLine();
            }

            if (totalWood > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalWood} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {beaver.Branches.Count} wood branches: {string.Join(", ", beaver.Branches)}.");
            }

            PrintMatrix(matrix, size, beaver);

        }

        private static bool IsWood(char currentPosition) => currentPosition >= 97 && currentPosition <= 122;

        private static void PrintMatrix(char[,] matrix, int size, Beaver beaver)
        {
            matrix[beaver.X, beaver.Y] = 'B';
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static bool ValidatePosition(int currentX, int currentY, int size) => currentX >= 0 && currentY >= 0 && currentX < size && currentY < size;

        private static char[,] FillMatrix(int size, ref int wood, Beaver beaver)
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
                        beaver.X = row;
                        beaver.Y = col;
                        matrix[row, col] = '-';
                    }

                    if (IsWood(currentElement))
                    {
                        wood++;
                    }
                }
            }

            return matrix;
        }
    }

    public class Beaver
    {
        public int X { get; set; }
        public int Y { get; set; }
        public List<char> Branches { get; set; }
        public Beaver()
        {
            Branches = new List<char>();
        }

    }
}