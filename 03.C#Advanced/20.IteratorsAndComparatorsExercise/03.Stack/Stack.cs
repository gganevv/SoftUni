using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public List<T> Elements
        {
            get { return elements; }
            set { elements = value; }
        }

        public Stack()
        {
            elements = new List<T>();
        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                Elements.Add(element);
            }
        }

        public T Pop()
        {
            if (Elements.Count == 0)
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            else
            {
                T element = Elements[Elements.Count - 1];
                Elements.RemoveAt(Elements.Count - 1);
                return element;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = elements.Count - 1; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
