using System;

public partial class HelpAMole
{
    static void Main(string[] args)
    {
        int size = int.Parse(Console.ReadLine());
        char[,] matrix = new char[size, size];
        FillMatrix(size, matrix);

        Mole mole = new Mole();
        mole.GetPosition(matrix);

        string input = Console.ReadLine();
        while (input != "End" && mole.Points < 25)
        {
            int currentRow = 0;
            int currentCol = 0;

            switch (input)
            {
                case "up":
                    currentRow = mole.X - 1;
                    currentCol = mole.Y;
                    break;
                case "down":
                    currentRow = mole.X + 1;
                    currentCol = mole.Y;
                    break;
                case "left":
                    currentRow = mole.X;
                    currentCol = mole.Y - 1;
                    break;
                case "right":
                    currentRow = mole.X;
                    currentCol = mole.Y + 1;
                    break;
                default:
                    break;
            }

            bool validIndices = CheckIndices(currentRow, currentCol, size);
            if (!validIndices)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                input = Console.ReadLine();
                continue;
            }

            char currnetField = matrix[currentRow, currentCol];
            int prevY = mole.Y;
            int prevX = mole.X;

            if (currnetField == '-')
            {
                mole.X = currentRow;
                mole.Y = currentCol;
                matrix[mole.X, mole.Y] = 'M';
            }
            else if (currnetField == 'S')
            {
                matrix[currentRow, currentCol] = '-';
                Teleport(matrix, mole);
                mole.Points -= 3;
            }
            else if (currnetField == 'M')
            {
                continue;
            }
            else
            {
                matrix[currentRow, currentCol] = 'M';
                mole.Points += int.Parse(currnetField.ToString());
                mole.X = currentRow;
                mole.Y = currentCol;
            }
            matrix[prevX, prevY] = '-';

            input = Console.ReadLine();
        }

        if (mole.Points >= 25)
        {
            Console.WriteLine("Yay! The Mole survived another game!");
            Console.WriteLine($"The Mole managed to survive with a total of {mole.Points} points.");
        }
        else
        {
            Console.WriteLine("Too bad! The Mole lost this battle!");
            Console.WriteLine($"The Mole lost the game with a total of {mole.Points} points.");
        }

        PrintMatrix(matrix);
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

    private static void Teleport(char[,] matrix, Mole mole)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == 'S')
                {
                    matrix[mole.X, mole.Y] = '-';
                    mole.X = row;
                    mole.Y = col;
                    matrix[row, col] = 'M';
                    return;
                }
            }
        }
    }

    private static bool CheckIndices(int currentRow, int currentCol, int size)
    {
        if (currentRow >= 0 && currentRow < size && currentCol >= 0 && currentCol < size)
        {
            return true;
        }
        return false;
    }

    private static void FillMatrix(int size, char[,] matrix)
    {
        for (int row = 0; row < size; row++)
        {
            char[] colElements = Console.ReadLine().ToCharArray();
            for (int col = 0; col < size; col++)
            {
                matrix[row, col] = colElements[col];
            }
        }
    }
}