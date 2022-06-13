using System;

namespace _06.WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            int rowCounter = 0;
            int totalSeatsCounter = 0;
            for (char i = 'A'; i <= lastSector; i++)
            {
                for (int r = 1; r <= rows + rowCounter; r++)
                {
                    int seatsCounter = r % 2 == 0 ? 2 : 0;
                    for (char s = 'a'; s < seats + 97 + seatsCounter; s++)
                    {
                        Console.WriteLine($"{(char)i}{r}{(char)s}");
                        totalSeatsCounter++;
                    }
                }
                rowCounter++;
            }
            Console.WriteLine(totalSeatsCounter);
        }
    }
}
