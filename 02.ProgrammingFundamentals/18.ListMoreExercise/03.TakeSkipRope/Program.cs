using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            List<int> numbersList = new List<int>();
            List<string> charList = new List<string>();
            string message = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    numbersList.Add(int.Parse(str[i].ToString()));
                }
                else
                {
                    charList.Add(str[i].ToString());
                }
            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < numbersList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbersList[i]);
                }
                else
                {
                    skipList.Add(numbersList[i]);
                }
            }
            int skipped = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                message += string.Join("", charList.Skip(skipped).Take(takeList[i]).ToArray());
                skipped += skipList[i] + takeList[i];
            }

            Console.WriteLine(message);
        }
    }
}
