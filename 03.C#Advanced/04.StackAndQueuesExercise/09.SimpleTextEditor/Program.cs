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
                        AppendText(text, memory, inputArgs);
                        break;
                    case "2":
                        RemoveText(text, memory, inputArgs);
                        break;
                    case "3":
                        ReturnText(text, inputArgs);
                        break;
                    case "4":
                        text = Undo(memory);
                        break;
                    default:
                        break;
                }
            }
        }

        private static StringBuilder Undo(Stack<string> memory)
        {
            StringBuilder text;
            memory.Pop();
            if (memory.Count > 0)
            {
                text = new StringBuilder(memory.Peek());
            }
            else
            {
                text = new StringBuilder();
            }

            return text;
        }

        private static void ReturnText(StringBuilder text, string[] inputArgs)
        {
            int indexToReturn = int.Parse(inputArgs[1]) - 1;
            Console.WriteLine(text[indexToReturn]);
        }

        private static void RemoveText(StringBuilder text, Stack<string> memory, string[] inputArgs)
        {
            int index = text.Length - int.Parse(inputArgs[1]);
            int length = text.Length - index;
            text.Remove(index, length);
            memory.Push(text.ToString());
        }

        private static void AppendText(StringBuilder text, Stack<string> memory, string[] inputArgs)
        {
            text.Append(inputArgs[1]);
            memory.Push(text.ToString());
        }
    }
}
