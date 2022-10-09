using System;

namespace _03.CustomQueue
{
    public class CustomQueue
    {
        const int INITIAL_CAPACITY = 4;
        const int FIRST_ELEMENT_INDEX = 0;
        private int[] items;
        private int count;

        public CustomQueue()
        {
            this.items = new int[INITIAL_CAPACITY];
            this.count = 0;
        }

        public int Count => this.count;

        public void Enqueue(int element)
        {
            if (this.items.Length == this.count)
            {
                Resize();
            }
            this.items[this.count] = element;
            this.count++;
        }

        public int Dequeue()
        {
            CheckQueueStatus();
            int element = this.items[FIRST_ELEMENT_INDEX];
            for (int i = 0; i < count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.count--;
            return element;
        }

        public int Peek()
        {
            CheckQueueStatus();
            return this.items[FIRST_ELEMENT_INDEX];
        }

        public void Clear()
        {
            CheckQueueStatus();
            this.items = new int[this.items.Length];
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(this.items[i]);
            }
        }

        private void Resize()
        {
            int[] newArr = new int[count * 2];
            for (int i = 0; i < this.count; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;
        }

        private void CheckQueueStatus()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Queue is empty.");
            }
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += this.items[i] + " ";
            }
            return result;
        }
    }
}
