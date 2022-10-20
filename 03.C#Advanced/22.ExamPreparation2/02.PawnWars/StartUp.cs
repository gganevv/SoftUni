using System;

namespace _02.PawnWars
{
    public class StartUp
    {
        static void Main()
        {
            int blackX = 0;
            int blackY = 0;

            int whiteX = 0;
            int whiteY = 0;
            bool whiteTurn = true;

            char[,] chessBoard = new char[8, 8];
            for (int row = 0; row < 8; row++)
            {
                char[] colElements = Console.ReadLine().ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    if (colElements[col] == 'b')
                    {
                        blackX = row;
                        blackY = col;
                    }
                    if (colElements[col] == 'w')
                    {
                        whiteX = row;
                        whiteY = col;
                    }
                    chessBoard[row, col] = colElements[col];
                }
            }

            while (true)
            {
                if (whiteTurn)
                {
                    if (ValidateIndex(whiteX - 1, whiteY - 1))
                    {
                        if (chessBoard[whiteX - 1, whiteY - 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(whiteY - 1 + 97)}{8 - whiteX + 1}.");
                            break;
                        }
                    }
                    if (ValidateIndex(whiteX - 1, whiteY + 1))
                    {
                        if (chessBoard[whiteX - 1, whiteY + 1] == 'b')
                        {
                            Console.WriteLine($"Game over! White capture on {(char)(whiteY + 1 + 97)}{8 - whiteX + 1}.");
                            break;
                        }
                    }
                    

                    if (whiteX - 1 == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteY + 97)}{8 - whiteX + 1}.");
                        
                        break;
                    }
                    else
                    {
                        chessBoard[whiteX - 1, whiteY] = 'w'; 
                        whiteX--;
                    }
                }
                else
                {
                    if (ValidateIndex(blackX + 1, blackY - 1))
                    {
                        if (chessBoard[blackX + 1, blackY - 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {(char)(blackY - 1 + 97)}{8 - blackX - 1}.");
                            break;
                        }
                    }

                    if (ValidateIndex(blackX + 1, blackY + 1))
                    {
                        if (chessBoard[blackX + 1, blackY + 1] == 'w')
                        {
                            Console.WriteLine($"Game over! Black capture on {(char)(blackY + 1 + 97)}{8 - blackX - 1}.");
                            break;
                        }
                    }
                    
                    if (blackX + 1 == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackY + 97)}{8 - blackX - 1}.");
                        break;
                    }
                    else
                    {
                        chessBoard[blackX + 1, blackY] = 'b';
                        blackX++;
                    }

                }

                whiteTurn = !whiteTurn;
            }

            bool ValidateIndex(int y, int x)
            {
                if (y <= 7 && y >= 0 && x <= 7 && x >= 0)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
