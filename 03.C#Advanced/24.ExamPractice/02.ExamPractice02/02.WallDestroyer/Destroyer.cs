namespace _02.WallDestroyer
{
    public class Destroyer
    {
        public Destroyer()
        {
            Electrocuted = false;
            HolesMade = 1;
            RodsHit = 0;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Electrocuted { get; set; }
        public int HolesMade { get; set; }
        public int RodsHit { get; set; }

        public char[,] FindStartingPosition(char[,] matrix, int wallSize)
        {
            for (int row = 0; row < wallSize; row++)
            {
                for (int col = 0; col < wallSize; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        X = row;
                        Y = col;
                        matrix[row, col] = '*';
                    }
                }
            }

            return matrix;
        }

        public int[] Move(string command, char[,] matrix)
        {
            switch (command)
            {
                case "up":
                    return new int[] { X - 1, Y };
                case "down":
                    return new int[] { X + 1, Y };
                case "left":
                    return new int[] { X, Y - 1 };
                case "right":
                    return new int[] { X, Y + 1 };
            }

            return null;
        }
    }

}
