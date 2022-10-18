using System;

namespace _02.WallDestroyer
{
    internal class StartUp
    {
        static void Main()
        {
            int wallSize = int.Parse(Console.ReadLine());
            Destroyer vanko = new Destroyer();
            char[,] matrix = FillMatrix(wallSize, vanko);

            string command = Console.ReadLine();
            while (command != "End" && !vanko.Electrocuted)
            {
                int[] newPosition = vanko.Move(command, matrix);

                bool validPosition = ValidatePosotion(newPosition, wallSize);
                if (validPosition)
                {
                    CheckNewPosition(matrix, vanko, newPosition);
                }

                command = Console.ReadLine();
            }

            string result = vanko.Electrocuted ? $"Vanko got electrocuted, but he managed to make {vanko.HolesMade} hole(s)." : $"Vanko managed to make {vanko.HolesMade} hole(s) and he hit only {vanko.RodsHit} rod(s).";
            Console.WriteLine(result);
            PrintMatrix(matrix, wallSize, vanko);
        }

        private static void CheckNewPosition(char[,] matrix, Destroyer vanko, int[] newPosition)
        {
            int newX = newPosition[0];
            int newY = newPosition[1];
            char currentWallPos = matrix[newX, newY];

            switch (currentWallPos)
            {
                case 'R':
                    vanko.RodsHit++;
                    Console.WriteLine("Vanko hit a rod!");
                    break;
                case 'C':
                    vanko.Electrocuted = true;
                    matrix[newX, newY] = 'E';
                    vanko.HolesMade++;
                    break;
                case '*':
                    Console.WriteLine($"The wall is already destroyed at position [{newX}, {newY}]!");
                    vanko.X = newX;
                    vanko.Y = newY;
                    break;
                default:
                    vanko.HolesMade++;
                    matrix[newX, newY] = '*';
                    vanko.X = newX;
                    vanko.Y = newY;
                    break;
            }
        }

        private static bool ValidatePosotion(int[] newPosition, int wallSize)
        {
            if (newPosition[0] >= 0 && newPosition[1] >= 0 && newPosition[0] < wallSize && newPosition[1] < wallSize)
            {
                return true;
            }
            return false;
        }

        private static void PrintMatrix(char[,] matrix, int wallSize, Destroyer vanko)
        {
            if (!vanko.Electrocuted)
            {
                matrix[vanko.X, vanko.Y] = 'V';
            }
            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] FillMatrix(int wallSize, Destroyer vanko)
        {
            char[,] matrix = new char[wallSize, wallSize];
            for (int row = 0; row < wallSize; row++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < wallSize; col++)
                {
                    matrix[row, col] = colElements[col];
                    if (matrix[row, col] == 'V')
                    {
                        vanko.X = row;
                        vanko.Y = col;
                        matrix[row, col] = '*';
                    }
                }
            }

            return matrix;
        }
    }
}
