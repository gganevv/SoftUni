using System;
using System.Numerics;

namespace _11.Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger bestSnowballValue = int.MinValue;
            string bestSnowBallFormula = "";
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowballValue = snowballSnow / snowballTime;
                snowballValue = BigInteger.Pow(snowballValue, snowballQuality);
                if (snowballValue > bestSnowballValue)
                {
                    bestSnowballValue = snowballValue;
                    bestSnowBallFormula = $"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})";
                }
            }

            Console.WriteLine(bestSnowBallFormula);
        }
    }
}
