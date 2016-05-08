using MyCollections;

namespace MyCollections
{
    public class MyQueue<T> : MyCollectionWithOneSideElements<T>
    {
        public MyQueue() : base() {}

        /// <summary>
        ///     Dodaje domyslny element do kolejki
        /// </summary>
        public void Enqueue()
        { this.Enqueue(default(T)); }

        /// <summary>
        ///     Dodaje element do kolejki
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            Element<T> new_element = new Element<T>(item);

            if (isEmpty())
                first = last = new_element;
            else
            {
                last.next_element = new_element;
                last = last.next_element;
            }

            Count++; // aktualizacja ilosci
        }

        /// <summary>
        ///     Zwraca pierwszy element w kolejce i usuwa go
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (isEmpty())
                throw new EmptyException();

            Element<T> tmp_first = first;

            SkipToNextElement(ref first);

            if (isEmpty())
                last = first;

            Count--; // aktualizacja ilosci

            return tmp_first.item;
        }

        /// <summary>
        ///     Zwraca pierwszy element w kolejce bez usuwania go
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (isEmpty())
                throw new EmptyException();

            return first.item;
        }
    }
}
