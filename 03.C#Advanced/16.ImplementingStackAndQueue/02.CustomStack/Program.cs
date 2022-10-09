using System;

namespace _02.CustomStack
{
    class Program
    {
        static void Main()
        {
            CustomStack customStack = new CustomStack();
            customStack.Push(1);
            customStack.Push(2);
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack);
        }
    }
}
