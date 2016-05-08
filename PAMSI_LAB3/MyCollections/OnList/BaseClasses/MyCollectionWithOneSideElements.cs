using System;
using System.Collections;
using System.Collections.Generic;
using MyCollections;

namespace MyCollections
{
    #region WithOneSideElement
    public abstract class MyCollectionWithOneSideElements<T> : MyCollection<T>, IEnumerable<T>, IEnumerator<T>
    {
        protected Element<T> first = null, last = null, current = null; // referencje do elementow
        private int idx = -1; // indeks do enumeracji


        /// <summary>
        ///     Konstruktor
        /// </summary>
        public MyCollectionWithOneSideElements() { }

        public void Clear()
        {
            first = last = null;
            Count = 0;
        }

        /// <summary>
        ///     Zwraca referencje do elementu o zadanym indeksie - funkcja pomocnicza
        /// </summary>
        protected Element<T> ReferenceToElementAt(int idx)
        {
            if (isIndexOutOfRange(idx)) // indeks poza zakresem listy
                throw new IndexOutOfRangeException(); // rzucenie wyjatku, wyjscie

            Element<T> element = first; // ustatwienie ref_ na referencje do pierwszego obiektu na liscie

            for (int i = 0; i < idx; i++)
                SkipToNextElement(ref element);

            return element;
        }

        /// <summary>
        ///     Przechodzi do nastepnego elementu
        /// </summary>
        /// <param name="element"></param>
        protected void SkipToNextElement(ref Element<T> element)
        { element = element.next_element; } // slowo kluczowe "ref" jest konieczne do zmiany referencji wewnatrz funkcji

        /// <summary>
        ///     Klasa przechowujaca pojedynczy element kolekcji - dany obiekt i referencje do nastepnego elementu
        /// </summary>
        /// <typeparam name="T_"></typeparam>
        public class Element<T_>
        {
            public T_ item; // obiekt kolekcji
            public Element<T_> next_element = null; // nastepny element

            public Element() : this(default(T_)) { } // konstruktor ustawiajacy domyslna wartosc przechowywanego obiektu

            public Element(T_ item) // konstuktor
            { this.item = item; }
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

        #region Enumerator_OneSide        
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
