using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public Stack<T> stack;

        public Box()
        {
            this.stack = new Stack<T>();
        }

        public void Add(T element)
        {
            this.stack.Push(element);
            this.Count++;
        }

        public T Remove()
        {
            this.Count--;
            return this.stack.Pop();
        }

        public int Count { get; set; }
    }
}
