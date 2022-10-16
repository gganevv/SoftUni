using System;

namespace _02.WallDestroyer
{
    public class StartUp
    {
        static void Main()
        {
            int wallSize = int.Parse(Console.ReadLine());
            char[,] matrix = FillMatrix(wallSize);

            Destroyer vanko = new Destroyer();
            matrix = vanko.FindStartingPosition(matrix, wallSize);

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

            if (!vanko.Electrocuted)
            {
                Console.WriteLine($"Vanko managed to make {vanko.HolesMade} hole(s) and he hit only {vanko.RodsHit} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {vanko.HolesMade} hole(s).");
            }

            PrintMatrix(matrix, wallSize, vanko);
        }

        private static void CheckNewPosition(char[,] matrix, Destroyer vanko, int[] newPosition)
        {
            int newX = newPosition[0];
            int newY = newPosition[1];
            char currentWallPos = matrix[newX, newY];

            if (currentWallPos == 'R')
            {
                vanko.RodsHit++;
                Console.WriteLine("Vanko hit a rod!");
            }
            else if (currentWallPos == 'C')
            {
                vanko.Electrocuted = true;
                matrix[newX, newY] = 'E';
                vanko.HolesMade++;
            }
            else if (currentWallPos == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{newX}, {newY}]!");
                vanko.X = newX;
                vanko.Y = newY;
            }
            else
            {
                vanko.HolesMade++;
                matrix[newX, newY] = '*';
                vanko.X = newX;
                vanko.Y = newY;
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

        private static char[,] FillMatrix(int wallSize)
        {
            char[,] matrix = new char[wallSize, wallSize];
            for (int row = 0; row < wallSize; row++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < wallSize; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            return matrix;
        }
    }

}
