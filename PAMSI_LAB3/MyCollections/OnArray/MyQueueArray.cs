using System;

namespace MyCollections
{
    public class MyQueueArray<T> : MyCollectionArray<T>
    {
        private int idx_first = 0;
        public MyQueueArray(int max_size, int resizeC = 0) : base(max_size, resizeC) { }

        public void Enqueue(T item)
        {
            if (IsIndexOutOfRange())
                Resize();

            elements[GetNextIndex()] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new EmptyException();

            Count--;

            return elements[idx_first = (++idx_first % MaxSize)];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyException();

            return elements[idx_first];
        }

        private int GetNextIndex()
        {
            return (Count++ + idx_first) % MaxSize;
        }

        public override T this[int idx]
        {
            get { return elements[(idx + idx_first) % MaxSize]; }
        }
    }
}
