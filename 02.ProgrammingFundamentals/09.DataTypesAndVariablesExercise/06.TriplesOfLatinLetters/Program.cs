using System;

namespace _06.TriplesOfLatinLetters
{
    class Program
    {
        static void Main(string[] args)
        {
            const int START_OF_ASCII = 97;
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        char firstChar = (char)(START_OF_ASCII + i);
                        char secondChar = (char)(START_OF_ASCII + j);
                        char thirdChar = (char)(START_OF_ASCII + k);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
