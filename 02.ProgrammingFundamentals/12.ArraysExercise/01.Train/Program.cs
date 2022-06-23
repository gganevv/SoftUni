using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] asd = { 1, 5325, 7 };

            Console.WriteLine(asd.Min());





            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] wagons = new int[numberOfWagons];

            
            for (int i = 0; i < numberOfWagons; i++)
            {
                wagons[i] = int.Parse(Console.ReadLine());
            }

            foreach (int passangers in wagons)
            {
                Console.Write(passangers + " ");
            }
            Console.WriteLine();
            Console.WriteLine(wagons.Sum());
        }
    }
}
