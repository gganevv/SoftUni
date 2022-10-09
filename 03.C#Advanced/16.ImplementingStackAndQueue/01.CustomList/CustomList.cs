using System;

namespace _01.CustomList
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                ValidateIndex(index);
                return items[index];
            }
            set
            {
                ValidateIndex(index);
                items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            ValidateIndex(index);
            int item = this.items[index];
            this.items[index] = default(int);
            this.ShiftLeft(index);
            this.Count--;
            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public void Insert(int index, int item)
        {
            ValidateIndex(index);
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(int element)
        {
            foreach (var item in this.items)
            {
                if (item == element)
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void Resize()
        {
            int[] newArr = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;
        }

        private void Shrink()
        {
            int[] newArr = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.items[i];
            }

            this.items = newArr;
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override string ToString()
        {
            return String.Join(", ", this.items);
        }
    }
}
