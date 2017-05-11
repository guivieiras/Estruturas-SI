using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests {
    public class SequencialHashMap<K, V> {
        private DoublyLinkedKeyValue<K, V> first;
        private DoublyLinkedKeyValue<K, V> last;

        private int Count = 0;

        public void InsertAt(DoublyLinkedKeyValue<K, V> element, int position) {
            if (Count == 0) {
                first = element;
                last = element;
                Count++;
                return;
            }
            if (position == Count) {
                last.Next = element;
                element.Previous = last;
                last = element;
                Count++;
                return;
            }

            DoublyLinkedKeyValue<K, V> iterator = first;
            int i = 0;
            while (i++ < position)
                iterator = iterator.Next;

            iterator.Previous.Next = element;
            element.Previous = iterator.Previous;
            element.Next = iterator;
            iterator.Previous = element;

            Count++;
        }

        public void Add(DoublyLinkedKeyValue<K, V> element) {
            InsertAt(element, Count);
        }

        public void InserBeforeFirst(DoublyLinkedKeyValue<K, V> element) {
            InsertAt(element, 0);
        }

        public void InserAfter(DoublyLinkedKeyValue<K, V> old, DoublyLinkedKeyValue<K, V> novo) {
            if (old == last)
                Add(novo);

            DoublyLinkedKeyValue<K, V> iterator = first;
            int i = 0;
            while (!iterator.Equals(old)) {
                iterator = iterator.Next;
                i++;
            }

            InsertAt(novo, i + 1);
        }

        public void InserBefore(DoublyLinkedKeyValue<K, V> old, DoublyLinkedKeyValue<K, V> novo) {
            if (old == first)
                InserBeforeFirst(novo);

            DoublyLinkedKeyValue<K, V> iterator = first;
            int i = 0;
            while (!iterator.Equals(old)) {
                iterator = iterator.Next;
                i++;
            }

            InsertAt(novo, i);
        }

        public DoublyLinkedKeyValue<K, V> getElementAt(int position) {
            DoublyLinkedKeyValue<K, V> iterator = first;
            int i = 0;
            while (i++ < position)
                iterator = iterator.Next;

            return iterator;
        }

        public DoublyLinkedKeyValue<K, V> getElement(K element) {
            DoublyLinkedKeyValue<K, V> iterator = first;

            while (!iterator.ID.Equals(element))
                iterator = iterator.Next;

            return iterator;
        }

        public void removeElementAt(int position) {
            if (Count == 1) {
                last = null;
                first = null;

                Count--;
                return;
            }

            DoublyLinkedKeyValue<K, V> iterator = first;
            int i = 0;
            while (i++ < position)
                iterator = iterator.Next;

            iterator.Previous.Next = iterator.Next;
            iterator.Next.Previous = iterator.Previous;

            Count--;
        }
    }
}
