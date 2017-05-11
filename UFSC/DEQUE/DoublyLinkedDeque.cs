using Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEQUE {
    class DoublyLinkedDeque<T> {
        private DoublyLinkedElement<T> first;
        private DoublyLinkedElement<T> last;

        public static void Test() {
            LinkedDeque<int> d = new LinkedDeque<int>();

            d.PushBack(1);
            d.PushBack(2);
            d.PushFront(10);
            d.PushFront(8);
            Console.WriteLine(d.PopBack());
            Console.WriteLine(d.PopBack());

            Console.WriteLine(d.PopFront());
            Console.WriteLine(d.PopBack());



            LinkedDeque<int> ad = new LinkedDeque<int>();

            ad.PushBack(1);
            ad.PushFront(90);
            ad.PushFront(20);
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());
            ad.PushFront(3131);
            ad.PushFront(5235);
            ad.PushBack(75675);
            ad.PushFront(34534);
            Console.WriteLine(ad.PopFront());
            Console.WriteLine(ad.PopFront());
            Console.WriteLine(ad.PopBack());
            Console.WriteLine(ad.PopBack());
        }

        public void PushBack(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            DoublyLinkedElement<T> element = new DoublyLinkedElement<T>(valor);

            if (Empty) {
                first = element;
            } else {
                last.Next = element;
                element.Previous = last;
            }

            last = element;
        }
        public T PopBack() {
            if (Empty) throw new Exception("DEQUE empty.");

            last.Previous.Next = null;

            DoublyLinkedElement<T> temp = last;
            last = last.Previous;
            return temp.Valor;
        }

        public void PushFront(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            DoublyLinkedElement<T> element = new DoublyLinkedElement<T>(valor);

            if (Empty)
                last = element;
            else {
                first.Previous = element;
                element.Next = first;
            }

            first = element;
        }
        public T PopFront() {
            if (Empty) throw new Exception("DEQUE empty.");

            first.Next.Previous = null;

            DoublyLinkedElement<T> temp = last;
            first = first.Next;
            return temp.Valor;
        }

        public bool Empty {
            get { return first == null; }
        }

    }
}

