using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string strToRemove = Console.ReadLine();
            string str = Console.ReadLine();
            while (str.Contains(strToRemove))
            {
                int index = str.IndexOf(strToRemove);
                str = str.Remove(index, strToRemove.Length);
            }
            Console.WriteLine(str);
        }
    }
}
