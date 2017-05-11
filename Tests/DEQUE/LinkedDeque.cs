using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DEQUE {
    public class LinkedDeque<T> {

        private LinkedElement<T> first;
        private LinkedElement<T> last;

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


        }

        public void PushBack(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            LinkedElement<T> element = new LinkedElement<T>(valor);

            if (last != null) last.setParent(element);
            else first = element;

            last = element;
        }
        public T PopBack() {
            if (Empty) throw new Exception("Queue empty.");

            LinkedElement<T> temp = first;


            while (temp.getParent() != last) {
                if (temp.getParent() == null) {
                    last = null;
                    first = null;
                    return temp.valor;
                }
                temp = temp.getParent();

            }

            temp.setParent(null);

            LinkedElement<T> temp2 = last;
            last = temp;
            return temp2.valor;
        }

        public void PushFront(T valor) {
            if (valor == null) throw new Exception("Invalid value: null");
            LinkedElement<T> element = new LinkedElement<T>(valor);

            if (first != null) element.setParent(first);
            else last = element;

            first = element;
        }
        public T PopFront() {
            if (Empty) throw new Exception("Queue empty.");

            LinkedElement<T> temp = first;

            first = first.getParent();

            if (first == null) last = null;

            return temp.valor;
        }

        public bool Empty {
            get { return first == null; }
        }

    }
}
