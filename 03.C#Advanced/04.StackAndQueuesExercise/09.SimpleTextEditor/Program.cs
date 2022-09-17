using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            Stack<string> memory = new Stack<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string command = inputArgs[0];
                switch (command)
                {
                    case "1":
                        text.Append(inputArgs[1]);
                        memory.Push(text.ToString());
                        break;
                    case "2":
                        int index = text.Length - int.Parse(inputArgs[1]);
                        int length = text.Length - index;
                        text.Remove(index, length);
                        memory.Push(text.ToString());
                        break;
                    case "3":
                        int indexToReturn = int.Parse(inputArgs[1]) - 1;
                        Console.WriteLine(text[indexToReturn]);
                        break;
                    case "4":
                        memory.Pop();
                        if (memory.Count > 0)
                        {
                            text = new StringBuilder(memory.Peek());
                        }
                        else
                        {
                            text = new StringBuilder();
                        }
                        
                        break;
                    default:
                        break;
                }
                
            }
        }
    }
}
