using System;
using System.Collections;
using System.Collections.Generic;

namespace MyCollections
{
    public abstract class MyCollection<T>
    {
        public int Count { get; protected set; }


        public MyCollection() { Count = 0; }


        public bool isEmpty()
        { return (Count <= 0); }

        protected bool isIndexOutOfRange(int idx)
        { return (idx >= this.Count || idx < 0); }
    }
}

