using System;

namespace _07.HousePainting
{
    class Program
    {
        static void Main(string[] args)
        {
            double houseHight = double.Parse(Console.ReadLine());
            double houseLenght = double.Parse(Console.ReadLine());
            double roofHigh = double.Parse(Console.ReadLine());

            double frontWall = houseHight * houseHight - 2.4;
            double backWall = houseHight * houseHight;
            double sideWalls = (houseHight * houseLenght - 2.25) * 2;
            double walls = sideWalls + backWall + frontWall;

            double roofSides = houseHight * houseLenght * 2;
            double roofFront = 2 * (houseHight * roofHigh / 2);
            double roof = roofSides + roofFront;

            double greenpaint = walls / 3.4;
            double redPaint = roof / 4.3;

            Console.WriteLine($"{greenpaint:f2}");
            Console.WriteLine($"{redPaint:f2}");
        }
    }
}
