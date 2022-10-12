public partial class HelpAMole
{
    public class Mole
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Points { get; set; }

        public void GetPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        X = row;
                        Y = col;
                        return;
                    }
                }
            }
        }
    }
}