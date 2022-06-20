using System;

namespace _08.BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            double bestKegVolume = int.MinValue;
            string bestKegModel = "";

            for (int i = 0; i < numberOfKegs; i++)
            {
                string currentKegModel = Console.ReadLine();
                double currentKegRadius = double.Parse(Console.ReadLine());
                int currentKegHeight = int.Parse(Console.ReadLine());

                double currentKegVolume = Math.PI * Math.Pow(currentKegRadius, 2) * currentKegHeight;
                if (currentKegVolume > bestKegVolume)
                {
                    bestKegVolume = currentKegVolume;
                    bestKegModel = currentKegModel;
                }
            }

            Console.WriteLine(bestKegModel);
        }
    }
}
