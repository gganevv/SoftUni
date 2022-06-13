using System;

namespace _07.SafePasswordGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int maxPass = int.Parse(Console.ReadLine());
            char j = '@';
            char i = '#';
            int counter = 0;

            for (int k = 1; k <= a; k++)
            {
                for (int l = 1; l <= b; l++, j++, i++)
                {
                    if (i == '8')
                    {
                        i = '#';
                    }
                    if (j == 'a')
                    {
                        j = '@';
                    }
                    Console.Write($"{i}{j}{k}{l}{j}{i}|");
                    counter++;
                    if (counter == maxPass)
                    {
                        return;
                    }
                }
            }
        }
    }
}
