using System;

namespace _02.BikeRice
{
    class Program
    {
        static void Main(string[] args)
        {
            int juniorBikers = int.Parse(Console.ReadLine());
            int seniorBikers = int.Parse(Console.ReadLine());
            string riceType = Console.ReadLine();
            double seniorFee = 0;
            double juniorFee = 0;

            switch (riceType)
            {
                case "trail":
                    juniorFee = 5.5;
                    seniorFee = 7;
                    break;
                case "cross-country":
                    juniorFee = 8;
                    seniorFee = 9.5;
                    break;
                case "downhill":
                    juniorFee = 12.25;
                    seniorFee = 13.75;
                    break;
                case "road":
                    juniorFee = 20;
                    seniorFee = 21.5;
                    break;
                default:
                    break;
            }
            double totalFee = (juniorFee * juniorBikers) + (seniorFee * seniorBikers);
            if (juniorBikers + seniorBikers >= 50 && riceType == "cross-country")
            {
                totalFee *= 0.75;
            }
            totalFee *= 0.95;
            Console.WriteLine($"{totalFee:f2}");
        }
    }
}
