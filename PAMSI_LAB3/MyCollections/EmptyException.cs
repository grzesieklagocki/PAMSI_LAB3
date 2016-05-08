using System;

namespace MyCollections
{
    public class EmptyException : Exception
    {
        public EmptyException() { }
        public EmptyException(string message) : base(message) { }
    }
}
