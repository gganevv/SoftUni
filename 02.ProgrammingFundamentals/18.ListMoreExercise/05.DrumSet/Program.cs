using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DrumSet
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> drumsInitialValue = new List<int>();
            drumsInitialValue.AddRange(drums);

            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int hitPower = int.Parse(input);
                for (int i = 0; i < drums.Count; i++)
                {
                    drums[i] -= hitPower;
                    if (drums[i] <= 0)
                    {
                        if (savings >= drumsInitialValue[i] * 3)
                        {
                            drums[i] = drumsInitialValue[i];
                            savings -= drumsInitialValue[i] * 3;
                        }
                        else
                        {
                            drums.RemoveAt(i);
                            drumsInitialValue.RemoveAt(i);
                            i--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", drums));
            Console.WriteLine($"Gabsy has {savings:f2}lv.");
        }
    }
}
