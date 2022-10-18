using System.Collections;
using System.Collections.Generic;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public List<int> Stones
        {
            get { return stones; }
            set { stones = value; }
        }

        public Lake(List<int> stones)
        {
            Stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return Stones[i];
                }
            }
            for (int i = Stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return Stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
