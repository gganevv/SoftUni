using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => this.Count == 0;
        public Stack<string> AddRange(Stack<string> addedStr)
        {
            for (int i = 0; i < addedStr.Count; i++)
            {
                this.Push(addedStr.Pop());
            }
            return this;
        }
    }
}
