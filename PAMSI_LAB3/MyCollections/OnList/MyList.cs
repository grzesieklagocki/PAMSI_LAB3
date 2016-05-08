using System;
using MyCollections;

namespace MyCollections
{
    public class MyList<T> : MyCollectionWithOneSideElements<T>
    {
        /// <summary>
        ///     Konstruktor, tworzy pusta liste
        /// </summary>
        public MyList() : base() { }


        #region MyList_dodawanie
        /// <summary>
        ///     Dodaje domyslny element na koniec listy
        /// </summary>
        public void Add() // dodawanie pustego elementu do listy
        { this.Add(default(T)); }

        /// <summary>
        ///     Dodaje element na koniec listy
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item) // dodawanie elementu do listy
        {
            Element<T> new_element = new Element<T>(item); // stworzenie nowego elemntu listy, obiekt przekazywany przez konstruktor MyListElement<T>

            if (isEmpty()) // jesli lista jest pusta
                first = new_element; // ustawienie referencji do pierwszego obiektu
            else
                last.next_element = new_element; // ustawienie referencji

            last = new_element; // ustawienie referencji do ostatniego elementu

            Count++; // aktualiacja ilosci elementow na liscie
        }

        /// <summary>
        ///     Wstawia domyślny element w miejsce o podanym indeksie
        /// </summary>
        /// <param name="idx"></param>
        public void Insert(int idx) { Insert(default(T), idx); }

        /// <summary>
        ///     Wstawia element w miejsce o podanym indeksie
        /// </summary>
        /// <param name="item"></param>
        /// <param name="idx"></param>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public void Insert(T item, int idx)
        {
            if (isIndexOutOfRange(idx) && idx != Count) // jesli indeks poza zakresem listy
                throw new IndexOutOfRangeException(); // rzucenie wyjatku, wyjscie

            if (isEmpty() || idx == Count)
                Add(item);
            else
            {
                Element<T> tmp = ReferenceToElementAt(idx);
                Element<T> new_element = new Element<T>(item);

                new_element.next_element = tmp;

                if (idx == 0)
                    first = new_element;
                else
                    ReferenceToElementAt(idx - 1).next_element = new_element;

                Count++;
            }
        }
        #endregion

        #region MyList_Usuwanie
        /// <summary>
        ///     Usuwa elemnt o podanym indeksie
        /// </summary>
        /// <param name="idx"></param>
        /// <exception cref="System.IndexOutOfRangeException">Rzucany, gdy indeks nie nalezy do zakresu listy</exception>
        public void RemoveAt(int idx) // usuwanie elemntu spod zadanego indeksu listy
        {
            if (isIndexOutOfRange(idx) || isEmpty()) // indeks poza zakresem listy
                throw new IndexOutOfRangeException(); // rzucenie wyjatku, wyjscie

            //*** indeks w zakresie:

            if (idx == 0)
            {
                SkipToNextElement(ref first); // przepisanie referencji na obiekt będący zaraz za pierwszym elementem
                                                   // jeśli jest kilka elementow - na pierwszy kolejny za "glowa" listy
                                                   // jesli jest tylko jeden element - 
                                                   // next_item i tak jest domyslnie ustawiony na null (w konstruktorze)
                if (isEmpty()) // jesli nie bylo elementow na liscie
                    last = first; // to pierwszy dodany jest tez ostatnim
            }
            else
            {
                ReferenceToElementAt(idx - 1).next_element = (idx == Count - 1) ? null : ReferenceToElementAt(idx + 1); // analogicznie jak dla "glowy" listy, pominiecie jednego elementu

                if (idx == Count - 1)
                    last = ReferenceToElementAt(idx - 1);
            }

            Count--; // aktualiacja ilosci elementow na liscie

            // zwalnianie pamieci: w C# automatycznie, zajmuje sie tym Garbage Collector
            // zaleznie od przypadku: this.first albo MyListElement<T>.next_item juz nie jest referencja do naszego elementu listy
            // byla to jedyna w programie referencja do tego obiektu, wiec pamiec zostanie po jakims czasie automatycznie zwolniona
        }

        #endregion






    }
}
