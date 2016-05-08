using System;

namespace MyCollections
{
    public class MyStackArray<T> : MyCollectionArray<T>
    {
        public MyStackArray(int max_size, int resizeC = 0 ) : base(max_size, resizeC) { }

        public void Push(T item)
        {
            if (IsIndexOutOfRange())
                Resize();

            elements[Count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new EmptyException();

            return elements[--Count];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new EmptyException();

            return elements[Count - 1];
        }

        public override T this[int idx]
        {
            get
            {
                if (idx < Count)
                    return elements[Count - idx - 1];
                else
                    throw new EmptyException();
            }
        }
    }
}
