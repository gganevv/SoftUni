using System;
using System.Collections.Generic;

namespace _08.BalancedParwntheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] parenthesesToStack = Console.ReadLine().ToCharArray();
            Stack<char> parentheses = new Stack<char>();
            for (int i = 0; i < parenthesesToStack.Length; i++)
            {
                char currentCh = parenthesesToStack[i];
                if (currentCh == '(' || currentCh == '[' || currentCh == '{')
                {
                    parentheses.Push(currentCh);
                }
                else
                {
                    CheckLastChar(parentheses, currentCh);
                }
            }
            if (parentheses.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private static void CheckLastChar(Stack<char> parentheses, char currentCh)
        {
            if (parentheses.Count > 0)
            {
                char lastCh = parentheses.Peek();
                if (currentCh == ')' && lastCh == '(')
                {
                    parentheses.Pop();
                }
                else if (currentCh == ']' && lastCh == '[')
                {
                    parentheses.Pop();
                }
                else if (currentCh == '}' && lastCh == '{')
                {
                    parentheses.Pop();
                }
                else
                {
                    parentheses.Push(currentCh);
                }
            }
            else
            {
                parentheses.Push(currentCh);
            }
        }
    }
}
