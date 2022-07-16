using System;

namespace _01.BinaryDigitsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            int bCounter = 0;
            string numAsBinaryString = string.Empty;

            while (number > 0)
            {
                numAsBinaryString += number % 2;
                number /= 2;
            }

            for (int i = 0; i < numAsBinaryString.Length; i++)
            {
                if (numAsBinaryString[i] == b)
                {
                    bCounter++;
                }
            }

            Console.WriteLine(bCounter);
        }
    }
}
