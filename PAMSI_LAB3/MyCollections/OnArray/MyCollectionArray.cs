using System;

namespace MyCollections
{
    public abstract class MyCollectionArray<T>
    {
        protected T[] elements;
        public int MaxSize { get; protected set; }
        public int Count { get; protected set; }
        protected int ResizeC { get; set; } // o ile powiekszamy tablice przy kazdym przepelnieniu, dla 0: dwukrotnie
        
        public MyCollectionArray(int max_size, int resize_c = 0)
        {
            if (max_size < 1)
                throw new Exception("Rozmiar musi byc wiekszy od zera");

            elements = new T[max_size];
            MaxSize = max_size;
            Count = 0;
            ResizeC = resize_c;
        }

        public void Clear()
        {
            elements = new T[MaxSize];
            Count = 0;
        }

        public bool IsEmpty()
        {
            return (Count <= 0);
        }

        protected bool IsIndexOutOfRange()
        {
            return ((Count + 1) == MaxSize);
        }

        public virtual T this[int idx]
        {
            get
            {
                if (idx < Count)
                    return elements[idx];
                else
                    throw new EmptyException();
            }
        }

        protected void Resize()
        {
            Array.Resize(ref elements, ResizeC == 0 ? MaxSize *= 2 : MaxSize += ResizeC);
        }
    }
}
