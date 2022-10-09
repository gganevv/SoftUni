using System;

namespace _02.CustomStack
{
    public class CustomStack
    {
        const int INITIAL_CAPACITY = 4;
        private int[] items;
        private int count;

        public CustomStack()
        {
            this.items = new int[INITIAL_CAPACITY];
            this.count = 0;
        }

        public int Count 
        { 
            get
            {
                return this.count;
            }
 
        }

        public void Push(int element)
        {
            if (this.items.Length == this.count)
            {
                Resize();
            }
            this.items[this.count] = element;
            this.count++;
        }

        public int Pop()
        {
            CheckStackStatus();
            int element = this.items[this.count - 1];
            this.items[count - 1] = default(int);
            count--;
            return element;
        }

        public int Peek()
        {
            CheckStackStatus();
            return this.items[count - 1]; ;
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

        private void CheckStackStatus()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Stack is empty");
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