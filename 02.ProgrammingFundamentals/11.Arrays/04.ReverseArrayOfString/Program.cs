using System;
using System.Linq;

namespace _04.ReverseArrayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split().ToArray();
            for (int i = str.Length -1; i >= 0; i--)
            {
                Console.Write(str[i] + " ");
            }
        }
    }
}
