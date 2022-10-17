using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        public ListyIterator(List<T> elements)
        {
            Elements = elements;
            CurrentIndex = 0;
        }

        public List<T> Elements { get; set; }
        public int CurrentIndex { get; set; }

        public bool Move()
        {
            if (CurrentIndex < Elements.Count - 1)
            {
                CurrentIndex++;
                return true;
            }

            return false;
        }

        public bool HasNext()
        {
            return CurrentIndex < Elements.Count - 1;
        }

        public void Print()
        {
            try
            {
                Console.WriteLine(Elements[CurrentIndex]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in Elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>  GetEnumerator();
    }
}
