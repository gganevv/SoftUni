using System;

namespace _08.TennisRankList
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTournaments = int.Parse(Console.ReadLine());
            int points = int.Parse(Console.ReadLine());
            double earnedPoints = 0;
            double wonTournamets = 0;
            for (int i = 0; i < numberOfTournaments; i++)
            {
                string tournamentResult = Console.ReadLine();
                if (tournamentResult == "W")
                {
                    earnedPoints += 2000;
                    wonTournamets++;
                }
                else if (tournamentResult == "F")
                {
                    earnedPoints += 1200;
                }
                else
                {
                    earnedPoints += 720;
                }
            }
            Console.WriteLine($"Final points: {points + earnedPoints}");
            Console.WriteLine($"Average points: {Math.Floor(earnedPoints / numberOfTournaments)}");
            Console.WriteLine($"{wonTournamets / numberOfTournaments * 100:f2}%");
        }
    }
}
