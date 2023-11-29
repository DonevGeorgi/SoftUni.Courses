using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
        }

        public int Count { get; private set; }


        public void Push(T item)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = item;

            Count++;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T itemToRemove = items[Count - 1];

            Count--;

            return itemToRemove;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }


        private void Resize()
        {
            T[] resizesArray = new T[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                resizesArray[i] = items[i];
            }

            items = resizesArray;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
