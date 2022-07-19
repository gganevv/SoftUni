using System;

namespace _02.ASCIISumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCh = char.Parse(Console.ReadLine());
            char secondCh = char.Parse(Console.ReadLine());
            int sum = 0;
            string randomString = Console.ReadLine();

            for (int i = 0; i < randomString.Length; i++)
            {
                if (randomString[i] > firstCh && randomString[i] < secondCh)
                {
                    sum += randomString[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
