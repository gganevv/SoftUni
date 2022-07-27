using System;

namespace _02.RageQuit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string currnetChars = string.Empty;
            string resultingStr = string.Empty;
            
            for (int i = 0; i < input.Length; i++)
            {
                char currentCh = input[i];
                if (char.IsDigit(currentCh))
                {
                    string currChToStr = currentCh.ToString().ToUpper();
                    int asd = int.Parse(currentCh);
                }
                else
                {
                    currnetChars += currentCh;
                }
            }
        }
    }
}
