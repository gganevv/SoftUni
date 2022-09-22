using System;
using System.Linq;

namespace _10.RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];
            FillMatrix(rows, cols, matrix);

            int[] playerPosition = new int[2];
            playerPosition = FindStartPosition(matrix);
            bool playerDead = false;
            bool playerWon = false;

            char[] commands = Console.ReadLine().ToCharArray();
            for (int i = 0; i < commands.Length && !playerDead && !playerWon; i++)
            {
                MovePlayer(matrix, playerPosition, ref playerDead, ref playerWon, commands, i);
                SpreadBunnies(matrix, playerPosition, ref playerDead);
            }

            PrintMatrix(matrix);

            if (playerWon)
            {
                Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
            }
            else if (playerDead)
            {
                Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
            }
        }

        private static void MovePlayer(char[,] matrix, int[] playerPosition, ref bool playerDead, ref bool playerWon, char[] commands, int i)
        {
            switch (commands[i])
            {
                case 'L':
                    if (ValidCell(playerPosition[0], playerPosition[1] - 1, matrix))
                    {
                        if (matrix[playerPosition[0], playerPosition[1] - 1] == 'B')
                        {
                            playerPosition[1] = playerPosition[1] - 1;
                            playerDead = true;
                        }
                        else
                        {
                            matrix[playerPosition[0], playerPosition[1] - 1] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                            playerPosition[1] = playerPosition[1] - 1;
                        }
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        playerWon = true;
                    }
                    break;
                case 'R':
                    if (ValidCell(playerPosition[0], playerPosition[1] + 1, matrix))
                    {
                        if (matrix[playerPosition[0], playerPosition[1] + 1] == 'B')
                        {
                            playerPosition[1] = playerPosition[1] + 1;
                            playerDead = true;
                        }
                        else
                        {
                            matrix[playerPosition[0], playerPosition[1] + 1] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                            playerPosition[1] = playerPosition[1] + 1;
                        }
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        playerWon = true;
                    }
                    break;
                case 'U':
                    if (ValidCell(playerPosition[0] - 1, playerPosition[1], matrix))
                    {
                        if (matrix[playerPosition[0] - 1, playerPosition[1]] == 'B')
                        {
                            playerPosition[0] = playerPosition[0] - 1;
                            playerDead = true;
                        }
                        else
                        {
                            matrix[playerPosition[0] - 1, playerPosition[1]] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                            playerPosition[0] = playerPosition[0] - 1;
                        }
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        playerWon = true;
                    }
                    break;
                case 'D':
                    if (ValidCell(playerPosition[0] + 1, playerPosition[1], matrix))
                    {
                        if (matrix[playerPosition[0] + 1, playerPosition[1]] == 'B')
                        {
                            playerPosition[0] = playerPosition[0] + 1;
                            playerDead = true;
                        }
                        else
                        {
                            matrix[playerPosition[0] + 1, playerPosition[1]] = 'P';
                            matrix[playerPosition[0], playerPosition[1]] = '.';
                            playerPosition[0] = playerPosition[0] + 1;
                        }
                    }
                    else
                    {
                        matrix[playerPosition[0], playerPosition[1]] = '.';
                        playerWon = true;
                    }
                    break;
                default:
                    break;
            }
        }

        private static void SpreadBunnies(char[,] matrix, int[] playerPosition, ref bool playerDead)
        {
            char[,] newMatrix = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '.')
                    {
                        if (newMatrix[row, col] != 'B')
                        {
                            newMatrix[row, col] = '.';
                        }
                    }
                    else if (matrix[row, col] == 'P')
                    {
                        if (newMatrix[row, col] != 'B')
                        {
                            newMatrix[row, col] = 'P';
                        }
                    }
                    else
                    {
                        newMatrix[row, col] = 'B';
                        if (ValidCell(row - 1, col, matrix))
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                playerDead = true;
                            }
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (ValidCell(row + 1, col, matrix))
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                playerDead = true;
                            }
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (ValidCell(row, col - 1, matrix))
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                playerDead = true;
                            }
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (ValidCell(row, col + 1, matrix))
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                playerDead = true;
                            }
                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = newMatrix[row, col];
                }
            }

        }

        private static int[] FindStartPosition(char[,] matrix)
        {
            int[] position = new int[2];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        position = new int[] { row, col };
                    }
                }
            }
            return position;
        }

        private static void FillMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool ValidCell(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}