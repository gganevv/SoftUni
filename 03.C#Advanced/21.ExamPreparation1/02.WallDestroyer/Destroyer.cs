using System;
using System.Collections.Generic;
using System.Text;

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