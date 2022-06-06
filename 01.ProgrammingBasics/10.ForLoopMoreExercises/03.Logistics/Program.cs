using System;

namespace _03.Logistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLoads = int.Parse(Console.ReadLine());
            double busLoads = 0;
            double truckLoads = 0;
            double trainLoads = 0;
            double totalPrice = 0;
            int totalLoads = 0;

            for (int i = 0; i < numberOfLoads; i++)
            {
                int load = int.Parse(Console.ReadLine());
                totalLoads += load;
                if (load <= 3)
                {
                    busLoads += load;
                    totalPrice += load * 200;
                }
                else if (load < 12)
                {
                    truckLoads += load;
                    totalPrice += load * 175;
                }
                else
                {
                    trainLoads += load;
                    totalPrice += load * 120;
                }
            }
           
            Console.WriteLine($"{totalPrice / totalLoads:f2}");
            Console.WriteLine($"{busLoads / totalLoads * 100:f2}%");
            Console.WriteLine($"{truckLoads / totalLoads * 100:f2}%");
            Console.WriteLine($"{trainLoads / totalLoads * 100:f2}%");
        }
    }
}
