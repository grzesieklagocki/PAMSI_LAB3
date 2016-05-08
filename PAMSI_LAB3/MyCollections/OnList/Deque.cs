using MyCollections;

namespace MyCollections
{
    /// <summary>
    ///     Klasa abstrakcyjna, sluzy do pisania wlasnych kolekcji korzystajacych 
    ///     z elementow z referencjami tylko w jedna strone (do przodu)  
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyDeque<T> : MyCollectionWithTwoSidesElements<T>
    {
        /// <summary>
        ///     Konstruktor
        /// </summary>
        public MyDeque() : base() { }

        /// <summary>
        ///     Dodaje domyslny element na poczatek Deque
        /// </summary>
        public void AddFirst()
        { this.AddFirst(default(T)); }

        /// <summary>
        ///     Dodaje element na poczatek Deque
        /// </summary>
        /// <param name="item"></param>
        public void AddFirst(T item)
        {
            if (Count == 0)
                last = first = new ElementTwoSides<T>(item);
            else
                first = first.AddPrevious(item);

            Count++;
        }

        /// <summary>
        ///     Dodaje domyslny element na koniec Deque
        /// </summary>
        public void AddLast()
        { this.AddLast(default(T)); }

        /// <summary>
        ///     Dodaje element na koniec Deque
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            if (Count == 0)
                last = first = new ElementTwoSides<T>(item);
            else
                last = last.AddNext(item);

            Count++;
        }

        /// <summary>
        ///     Pobiera pierwszy element z Deque
        /// </summary>
        /// <returns></returns>
        public T PopFirst()
        {
            if (Count <= 0)
                throw new EmptyException();

            ElementTwoSides<T> first_tmp = first;

            if (--Count == 0)
                last = first;
            else
            {
                first = first.next_element;
                first.prev_element = null;
            }
             

            return first_tmp.item;
        }

        /// <summary>
        ///     Popiera ostatni element z Deque
        /// </summary>
        /// <returns></returns>
        public T PopLast()
        {
            if (isEmpty())
                throw new EmptyException();

            ElementTwoSides<T> last_tmp = last;

            if (--Count == 0)
                first = last;
            else
            {
                last = last.prev_element;
                last.next_element = null;
            }

            return last_tmp.item;
        }

        /// <summary>
        ///     Zwraca wartosc pierwszego elementu Deque bez usuwanie go
        /// </summary>
        /// <returns></returns>
        public T PeekFirst()
        {
            if (isEmpty())
                throw new EmptyException();

            return first.item;
        }

        /// <summary>
        ///     Zwraca wartosc ostatniego elementu Deque bez usuwanie go
        /// </summary>
        /// <returns></returns>
        public T PeekLast()
        {
            if (isEmpty())
                throw new EmptyException();

            return last.item;
        }
    }
}
