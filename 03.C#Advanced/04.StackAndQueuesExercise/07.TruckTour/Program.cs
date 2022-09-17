using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<GasStation> gasStations = new Queue<GasStation>();
            int numberOfStations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStations; i++)
            {
                int[] currentStation = Console.ReadLine().Split().Select(int.Parse).ToArray();
                gasStations.Enqueue(new GasStation(currentStation[0], currentStation[1]));
            }

            for (int i = 0; i < gasStations.Count; i++)
            {
                if(CanGetAllStations(gasStations))
                {
                    Console.WriteLine(i);
                    break;
                }

                gasStations.Enqueue(gasStations.Dequeue());
            }
        }

        private static bool CanGetAllStations(Queue<GasStation> gasStations)
        {
            bool enoughFuel = true;
            int tank = 0;
            for (int j = 0; j < gasStations.Count; j++)
            {
                tank += gasStations.Peek().Petroleum - gasStations.Peek().Distance;
                if (tank < 0)
                {
                    enoughFuel = false;
                }

                gasStations.Enqueue(gasStations.Dequeue());
            }
            return enoughFuel;
        }
    }
}