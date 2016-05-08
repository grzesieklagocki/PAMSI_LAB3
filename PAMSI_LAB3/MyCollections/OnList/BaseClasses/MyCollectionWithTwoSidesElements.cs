using System;
using System.Collections;
using System.Collections.Generic;
using MyCollections;

namespace MyCollections
{
    #region WithTwoSidesElement
    public abstract class MyCollectionWithTwoSidesElements<T> : MyCollection<T>, IEnumerable<T>, IEnumerator<T>
    {
        protected ElementTwoSides<T> first = null, last = null, current = null;
        private int idx = -1;


        /// <summary>
        ///     Konstruktor
        /// </summary>
        public MyCollectionWithTwoSidesElements() { }

        /// <summary>
        ///     Zwraca referencje do elementu o zadanym indeksie - funkcja pomocnicza
        /// </summary>
        protected ElementTwoSides<T> ReferenceToElementAt(int idx)
        {
            if (isIndexOutOfRange(idx)) // indeks poza zakresem listy
                throw new IndexOutOfRangeException(); // rzucenie wyjatku, wyjscie

            ElementTwoSides<T> element = first; // ustatwienie ref_ na referencje do pierwszego obiektu na liscie

            for (int i = 0; i < idx; i++)
                SkipToNextElement(ref element);

            return element;
        }

        /// <summary>
        ///     Przechodzi do nastepnego elementu
        /// </summary>
        /// <param name="element"></param>
        protected void SkipToNextElement(ref ElementTwoSides<T> element)
        { element = element.next_element; } // slowo kluczowe "ref" jest konieczne do zmiany referencji wewnatrz funkcji

        public void Clear()
        {
            first = last = null;
            Count = 0;
        }

        /// <summary>
        ///     Klasa przechowujaca pojedynczy element kolekcji - dany obiekt i referencje do nastepnego i poprzedniego elementu
        /// </summary>
        /// <typeparam name="T_"></typeparam>
        protected class ElementTwoSides<T_>
        {
            public T_ item; // obiekt kolekcji
            public ElementTwoSides<T_> next_element = null, prev_element = null; // referencje

            public ElementTwoSides() : this(default(T_)) { }
            public ElementTwoSides(T_ item) { this.item = item; } // konstruktor
            public ElementTwoSides(T_ item, ElementTwoSides<T_> next_element) : this(item) { this.next_element = next_element; } // konstruktor, dodatkowo ustawia referencje na nastepny element
            public ElementTwoSides(ElementTwoSides<T_> next_element, T_ item) : this(item) { this.prev_element = next_element; } // konstruktor, dodatkowo ustawia referencje na poprzedni element

            // dodaje nastepny element, tworzy automatycznie powiazania
            public ElementTwoSides<T_> AddPrevious(T_ item) { return prev_element = new ElementTwoSides<T_>(item, this); }
            // dodaje poprzedni element, - || -
            public ElementTwoSides<T_> AddNext(T_ item) { return next_element = new ElementTwoSides<T_>(this, item); }
        }

        /// <summary>
        ///     Przeciążenie operatora []
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public T this[int idx]
        {
            get { return ReferenceToElementAt(idx).item; }
            set { ReferenceToElementAt(idx).item = value; }
        }



        #region Enumerator_TwoSides
        /// <summary>
        ///     Tutaj znajduja sie metody wymagane przez interfejs IEnumerable
        ///     Implementacja tego interfejsu pozwala na przyklad na korzystanie z kolekcji w petlach foreach
        /// </summary>


        public IEnumerator<T> GetEnumerator()
        { Reset(); return this; } // niestety petla foreach nie wywoluje metody reset, trzeba wywolac ja recznie

        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }

        /// <summary>
        ///     Zwraca biezacy element kolekcji
        /// </summary>
        public T Current
        { get { return this.current.item; } }

        object IEnumerator.Current
        { get { return this.Current; } }

        /// <summary>
        ///     Sprawdzam czy jest mozliwosc przejscia do nastepnego elementu kolekcji,
        ///     jesli tak - przechodzi (ustawiana jest referencja odczytywana przez metode Current
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            if (++idx == Count) // za ostatnim elementem
                return false;
            else
            {
                if (idx > 0)
                    SkipToNextElement(ref current);

                return true;
            }
        }

        /// <summary>
        ///     Resetuje, ustawia sie przed pierwszym elementem kolekcji
        /// </summary>
        public void Reset()
        {
            idx = -1;
            current = first;
        }

        /// <summary>
        ///     Zwolnienie zasobow. W tym wypadku jest nieuzywane, 
        ///     jednak interefejs IEnumerable wymaga implementacji tej metody  
        /// </summary>
        public void Dispose()
        { /* throw new NotImplementedException(); */ }
    }
        #endregion
}
#endregion
