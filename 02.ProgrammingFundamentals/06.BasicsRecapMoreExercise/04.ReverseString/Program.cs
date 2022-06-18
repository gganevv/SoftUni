using System;

namespace _04.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            string reversedStr = "";
            for (int i = str.Length -1; i >= 0; i--)
            {
                reversedStr += str[i];
            }

            Console.WriteLine(reversedStr);
        }
    }
}
