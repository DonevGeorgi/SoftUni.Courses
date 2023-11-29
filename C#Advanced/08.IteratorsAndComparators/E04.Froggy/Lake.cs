using System.Collections;
using System.Collections.Generic;

namespace P04.Froggy
{
    public class Lake<T> : IEnumerable<T>
    {
        private T[] stones;

        public Lake(T[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < stones.Length; i++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            }

            for (int i = stones.Length - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
