using System;

namespace _10.PokeMon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            double halfStartingPokePower = pokePower / 2.0;
            int targetDistance = int.Parse(Console.ReadLine());
            int exhaustionFactor = int.Parse(Console.ReadLine());
            int pokesCount = 0;

            while (pokePower >= targetDistance)
            {
                pokePower -= targetDistance;
                pokesCount++;
                if (pokePower == halfStartingPokePower && exhaustionFactor > 0)
                {
                    pokePower /= exhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokesCount);
        }
    }
}
