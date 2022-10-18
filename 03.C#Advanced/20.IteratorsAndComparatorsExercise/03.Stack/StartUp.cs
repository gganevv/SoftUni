using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        static void Main()
        {
            Stack<string> stack = new Stack<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArgs = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string command = inputArgs[0];
                if (command == "Push")
                {
                    stack.Push(inputArgs.Skip(1).ToArray());
                }
                else
                {
                    stack.Pop();
                }

                input = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
