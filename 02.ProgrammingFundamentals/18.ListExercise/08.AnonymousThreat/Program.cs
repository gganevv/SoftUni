using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> strings = Console.ReadLine().Split().ToList();

            string line = Console.ReadLine();

            while (line != "3:1")
            {
                string[] commandArgs = line.Split();
                string command = commandArgs[0];
                int index = int.Parse(commandArgs[1]);
                int secondIndex = int.Parse(commandArgs[2]);

                if (command == "merge")
                {
                    MergeStrings(index, secondIndex, strings);
                }
                else
                {
                    DivideStrings(index, secondIndex, strings);
                }
                

                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", strings));
        }

        private static void MergeStrings(int index, int secondIndex, List<string> strings)
        {
            if (index < 0 || index > strings.Count - 1)
            {
                index = 0;
            }

            if (secondIndex < 0 || secondIndex > strings.Count - 1)
            {
                secondIndex = strings.Count - 1;
            }
            string tempStr = "";

            for (int i = index; i <= secondIndex; i++)
            {
                tempStr += strings[i];
            }

            strings.RemoveRange(index, secondIndex - index + 1);
            strings.Insert(index, tempStr);
        }

        private static void DivideStrings(int index, int count, List<string> strings)
        {
            List<string> tempList = new List<string>();
            int partLength = strings[index].Length / count;
            
            for (int i = 0; i < count; i++)
            {
                if (i == count - 1)
                {
                    tempList.Add(strings[index].Substring(i * partLength));
                }
                else
                {
                    tempList.Add(strings[index].Substring(i * partLength, partLength));
                }
            }

            strings.RemoveAt(index);
            strings.InsertRange(index, tempList);
        }

    }
}
