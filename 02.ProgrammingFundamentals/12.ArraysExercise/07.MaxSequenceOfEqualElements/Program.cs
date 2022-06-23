using System;
using System.Linq;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxSecuence = 0;
            int sequenceName = 0;
            int counter = 1;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    counter++;
                }
                else
                {
                    if (counter > maxSecuence)
                    {
                        maxSecuence = counter;
                        sequenceName = numbers[i];
                    }
                    counter = 1;
                }
            }
            if (counter > maxSecuence)
            {
                maxSecuence = counter;
                sequenceName = numbers[numbers.Length - 1];
            }

            for (int i = 0; i < maxSecuence; i++)
            {
                Console.Write(sequenceName + " ");
            }
        }
    }
}
